using FleetMaintenanceApi.Models;

namespace FleetMaintenanceApi.Repositories.Interfaces
{
    public interface IMaintenanceRepository
    {
        IQueryable<MaintenanceRecord> GetMaintenanceRecordsQueryable();
        Task AddMaintenanceRecordAsync(MaintenanceRecord maintenanceRecord);
        Task<MaintenanceRecord?> GetByIdAsync(int id);
        Task UpdateAsync(MaintenanceRecord record);
        Task DeleteAsync(MaintenanceRecord record);
    }
}