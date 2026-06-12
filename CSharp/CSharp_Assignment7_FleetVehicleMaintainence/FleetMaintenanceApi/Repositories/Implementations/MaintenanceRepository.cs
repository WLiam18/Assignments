using FleetMaintenanceApi.Data;
using FleetMaintenanceApi.Models;
using FleetMaintenanceApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FleetMaintenanceApi.Repositories.Implementations
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly FleetMaintenanceDbContext _context;

        public MaintenanceRepository(FleetMaintenanceDbContext context)
        {
            _context = context;
        }

        public IQueryable<MaintenanceRecord> GetMaintenanceRecordsQueryable()
        {
            return _context.MaintenanceRecords
                .Include(m => m.Vehicle)
                .Include(m => m.Driver)
                .AsQueryable();
        }

        public async Task AddMaintenanceRecordAsync(MaintenanceRecord maintenanceRecord)
        {
            _context.MaintenanceRecords.Add(maintenanceRecord);
            await _context.SaveChangesAsync();
        }

        public async Task<MaintenanceRecord?> GetByIdAsync(int id)
        {
            return await _context.MaintenanceRecords
                .Include(m => m.Vehicle)
                .Include(m => m.Driver)
                .FirstOrDefaultAsync(m => m.MaintenanceId == id);
        }

        public async Task UpdateAsync(MaintenanceRecord record)
        {
            _context.MaintenanceRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MaintenanceRecord record)
        {
            _context.MaintenanceRecords.Remove(record);
            await _context.SaveChangesAsync();
        }
    }
}