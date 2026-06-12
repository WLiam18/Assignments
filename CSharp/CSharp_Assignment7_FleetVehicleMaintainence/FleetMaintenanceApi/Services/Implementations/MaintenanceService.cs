using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Models;
using FleetMaintenanceApi.Repositories.Interfaces;
using FleetMaintenanceApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FleetMaintenanceApi.Services.Implementations
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepo;
        private readonly IVehicleRepository _vehicleRepo;
        private readonly IDriverRepository _driverRepo;

        public MaintenanceService(IMaintenanceRepository maintenanceRepo, IVehicleRepository vehicleRepo, IDriverRepository driverRepo)
        {
            _maintenanceRepo = maintenanceRepo;
            _vehicleRepo = vehicleRepo;
            _driverRepo = driverRepo;
        }

        public async Task<(bool Success, string Message, PagedResponseDto<MaintenanceResponseDto>? Data)> GetPagedMaintenanceRecordsAsync(MaintenanceFilterRequestDto filter)
        {
            if (filter.PageNumber <= 0)
                return (false, "Page number must be greater than zero", null);

            if (filter.PageSize <= 0)
                return (false, "Page size must be greater than zero", null);

            if (filter.PageSize > 100)
                return (false, "Page size cannot be greater than 100", null);

            var allowedSortFields = new List<string>
            {
                "maintenanceid", "servicedate", "servicetype", "servicecost",
                "servicestatus", "vehiclenumber", "drivername", "createddate"
            };

            // bonus qs 1 multiple field sorting 
            var sortFieldList = new List<string>();
            var sortDirectionList = new List<string>();

            if (!string.IsNullOrWhiteSpace(filter.SortBy))
            {
                var fields = filter.SortBy.ToLower().Split(',');
                
                var directions = new List<string>();
                if (!string.IsNullOrWhiteSpace(filter.SortDirection) && filter.SortDirection.Contains(','))
                {
                    directions = filter.SortDirection.ToLower().Split(',').ToList();
                }
                else
                {
                    for (int i = 0; i < fields.Length; i++)
                    {
                        directions.Add(filter.SortDirection?.ToLower() ?? "asc");
                    }
                }

                for (int i = 0; i < fields.Length; i++)
                {
                    var field = fields[i].Trim();
                    if (!allowedSortFields.Contains(field))
                        return (false, $"Invalid sort field: {fields[i]}", null);
                    
                    var dir = i < directions.Count ? directions[i] : "asc";
                    if (dir != "asc" && dir != "desc")
                        return (false, $"Invalid sort direction: {dir}", null);
                    
                    sortFieldList.Add(field);
                    sortDirectionList.Add(dir);
                }
            }

            var query = _maintenanceRepo.GetMaintenanceRecordsQueryable();

            if (filter.VehicleId.HasValue)
                query = query.Where(m => m.VehicleId == filter.VehicleId.Value);

            if (filter.DriverId.HasValue)
                query = query.Where(m => m.DriverId == filter.DriverId.Value);

            if (!string.IsNullOrWhiteSpace(filter.ServiceStatus))
                query = query.Where(m => m.ServiceStatus.ToLower() == filter.ServiceStatus.ToLower());

            if (filter.FromDate.HasValue)
                query = query.Where(m => m.ServiceDate >= filter.FromDate.Value);

            if (filter.ToDate.HasValue)
                query = query.Where(m => m.ServiceDate <= filter.ToDate.Value);

            // bonus qs 2 search by vehicle number
            if (!string.IsNullOrWhiteSpace(filter.VehicleNumber))
                query = query.Where(m => m.Vehicle.VehicleNumber.Contains(filter.VehicleNumber));

            // bonus qs 3 search by driver name
            if (!string.IsNullOrWhiteSpace(filter.DriverName))
                query = query.Where(m => m.Driver.DriverName.Contains(filter.DriverName));

            // bonus qs 1 multiple sorting
            if (sortFieldList.Count > 0)
            {
                IOrderedQueryable<MaintenanceRecord>? orderedQuery = null;
                
                for (int i = 0; i < sortFieldList.Count; i++)
                {
                    var field = sortFieldList[i];
                    var isDesc = sortDirectionList[i] == "desc";
                    
                    if (i == 0)
                    {
                        orderedQuery = field switch
                        {
                            "maintenanceid" => isDesc ? query.OrderByDescending(m => m.MaintenanceId) : query.OrderBy(m => m.MaintenanceId),
                            "servicedate" => isDesc ? query.OrderByDescending(m => m.ServiceDate) : query.OrderBy(m => m.ServiceDate),
                            "servicetype" => isDesc ? query.OrderByDescending(m => m.ServiceType) : query.OrderBy(m => m.ServiceType),
                            "servicecost" => isDesc ? query.OrderByDescending(m => m.ServiceCost) : query.OrderBy(m => m.ServiceCost),
                            "servicestatus" => isDesc ? query.OrderByDescending(m => m.ServiceStatus) : query.OrderBy(m => m.ServiceStatus),
                            "vehiclenumber" => isDesc ? query.OrderByDescending(m => m.Vehicle.VehicleNumber) : query.OrderBy(m => m.Vehicle.VehicleNumber),
                            "drivername" => isDesc ? query.OrderByDescending(m => m.Driver.DriverName) : query.OrderBy(m => m.Driver.DriverName),
                            "createddate" => isDesc ? query.OrderByDescending(m => m.CreatedDate) : query.OrderBy(m => m.CreatedDate),
                            _ => query.OrderBy(m => m.ServiceDate)
                        };
                    }
                    else
                    {
                        orderedQuery = field switch
                        {
                            "maintenanceid" => isDesc ? orderedQuery.ThenByDescending(m => m.MaintenanceId) : orderedQuery.ThenBy(m => m.MaintenanceId),
                            "servicedate" => isDesc ? orderedQuery.ThenByDescending(m => m.ServiceDate) : orderedQuery.ThenBy(m => m.ServiceDate),
                            "servicetype" => isDesc ? orderedQuery.ThenByDescending(m => m.ServiceType) : orderedQuery.ThenBy(m => m.ServiceType),
                            "servicecost" => isDesc ? orderedQuery.ThenByDescending(m => m.ServiceCost) : orderedQuery.ThenBy(m => m.ServiceCost),
                            "servicestatus" => isDesc ? orderedQuery.ThenByDescending(m => m.ServiceStatus) : orderedQuery.ThenBy(m => m.ServiceStatus),
                            "vehiclenumber" => isDesc ? orderedQuery.ThenByDescending(m => m.Vehicle.VehicleNumber) : orderedQuery.ThenBy(m => m.Vehicle.VehicleNumber),
                            "drivername" => isDesc ? orderedQuery.ThenByDescending(m => m.Driver.DriverName) : orderedQuery.ThenBy(m => m.Driver.DriverName),
                            "createddate" => isDesc ? orderedQuery.ThenByDescending(m => m.CreatedDate) : orderedQuery.ThenBy(m => m.CreatedDate),
                            _ => orderedQuery.ThenBy(m => m.ServiceDate)
                        };
                    }
                }
                
                if (orderedQuery != null)
                    query = orderedQuery;
            }
            else
            {
                query = query.OrderBy(m => m.ServiceDate);
            }

            int totalRecords = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

            var records = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var data = new List<MaintenanceResponseDto>();
            foreach (var m in records)
            {
                data.Add(new MaintenanceResponseDto
                {
                    MaintenanceId = m.MaintenanceId,
                    VehicleId = m.VehicleId,
                    VehicleNumber = m.Vehicle.VehicleNumber,
                    VehicleType = m.Vehicle.VehicleType,
                    DriverId = m.DriverId,
                    DriverName = m.Driver.DriverName,
                    ServiceDate = m.ServiceDate,
                    ServiceType = m.ServiceType,
                    ServiceCost = m.ServiceCost,
                    ServiceStatus = m.ServiceStatus,
                    Remarks = m.Remarks,
                    CreatedDate = m.CreatedDate
                });
            }

            var response = new PagedResponseDto<MaintenanceResponseDto>
            {
                StatusCode = 200,
                Message = "Maintenance records retrieved successfully",
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                HasPreviousPage = filter.PageNumber > 1,
                HasNextPage = filter.PageNumber < totalPages,
                Data = data
            };

            return (true, "Maintenance records retrieved successfully", response);
        }

        public async Task<(bool Success, string Message, MaintenanceResponseDto? Data)> AddMaintenanceRecordAsync(MaintenanceCreateDto dto)
        {
            bool vehicleExists = await _vehicleRepo.VehicleExistsAsync(dto.VehicleId);
            if (!vehicleExists)
                return (false, "Vehicle not found", null);

            bool driverExists = await _driverRepo.DriverExistsAsync(dto.DriverId);
            if (!driverExists)
                return (false, "Driver not found", null);

            var record = new MaintenanceRecord
            {
                VehicleId = dto.VehicleId,
                DriverId = dto.DriverId,
                ServiceDate = dto.ServiceDate,
                ServiceType = dto.ServiceType,
                ServiceCost = dto.ServiceCost,
                ServiceStatus = dto.ServiceStatus,
                Remarks = dto.Remarks,
                CreatedDate = DateTime.Now
            };

            await _maintenanceRepo.AddMaintenanceRecordAsync(record);

            var saved = _maintenanceRepo.GetMaintenanceRecordsQueryable()
                .FirstOrDefault(m => m.MaintenanceId == record.MaintenanceId);

            var response = new MaintenanceResponseDto
            {
                MaintenanceId = record.MaintenanceId,
                VehicleId = record.VehicleId,
                VehicleNumber = saved?.Vehicle?.VehicleNumber ?? "",
                VehicleType = saved?.Vehicle?.VehicleType ?? "",
                DriverId = record.DriverId,
                DriverName = saved?.Driver?.DriverName ?? "",
                ServiceDate = record.ServiceDate,
                ServiceType = record.ServiceType,
                ServiceCost = record.ServiceCost,
                ServiceStatus = record.ServiceStatus,
                Remarks = record.Remarks,
                CreatedDate = record.CreatedDate
            };

            return (true, "Maintenance record added successfully", response);
        }

        // bonus qs 4 update status field
        public async Task<(bool Success, string Message, MaintenanceResponseDto? Data)> UpdateStatusAsync(int id, string serviceStatus)
        {
            var record = await _maintenanceRepo.GetByIdAsync(id);
            
            if (record == null)
                return (false, "Maintenance record not found", null);

            string[] allowed = { "Scheduled", "InProgress", "Completed", "Cancelled" };
            if (!allowed.Contains(serviceStatus))
                return (false, "Invalid service status", null);

            record.ServiceStatus = serviceStatus;
            await _maintenanceRepo.UpdateAsync(record);

            var response = new MaintenanceResponseDto
            {
                MaintenanceId = record.MaintenanceId,
                VehicleId = record.VehicleId,
                VehicleNumber = record.Vehicle?.VehicleNumber ?? "",
                VehicleType = record.Vehicle?.VehicleType ?? "",
                DriverId = record.DriverId,
                DriverName = record.Driver?.DriverName ?? "",
                ServiceDate = record.ServiceDate,
                ServiceType = record.ServiceType,
                ServiceCost = record.ServiceCost,
                ServiceStatus = record.ServiceStatus,
                Remarks = record.Remarks,
                CreatedDate = record.CreatedDate
            };

            return (true, "Service status updated successfully", response);
        }

        // bonus qs 5 delete maintenance record by id
        public async Task<(bool Success, string Message)> DeleteMaintenanceRecordAsync(int id)
        {
            var record = await _maintenanceRepo.GetByIdAsync(id);
            
            if (record == null)
                return (false, "Maintenance record not found");

            await _maintenanceRepo.DeleteAsync(record);
            return (true, "Maintenance record deleted successfully");
        }
    }
}