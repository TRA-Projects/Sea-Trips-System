using Sea_Trips_System.DTOs;

namespace Sea_Trips_System.Models
{
    public class MaintenanceService
    {
        private MaintenanceRepo repo;

        public MaintenanceService(MaintenanceRepo _repo)
        {
            repo = _repo;
        }

        public List<MaintenanceResponseDto> GetAllMaintenance()
        {
            return repo.GetAllMaintenance()
                       .Select(m => new MaintenanceResponseDto
                       {
                           MaintenanceId = m.maintenanceId,
                           Description = m.description,
                           StartDate = m.startDate,
                           EndDate = m.endDate,
                           BoatId = m.boatId
                       })
                       .ToList();
        }
    }
}