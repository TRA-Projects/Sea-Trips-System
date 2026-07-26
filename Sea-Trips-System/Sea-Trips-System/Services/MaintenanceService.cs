using Sea_Trips_System.DTOs;

namespace Sea_Trips_System.Models
{
    public class MaintenanceService
    {
        private MaintenanceRepo repo;


        // Dependency Injection
        public MaintenanceService(MaintenanceRepo _repo)
        {
            repo = _repo;
        }



        // View All Maintenances
        public List<MaintenanceResponseDto> ViewAllMaintenances()
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



        // Add Maintenance
        public void AddMaintenance(AddMaintenanceDto dto)
        {
            Maintenance maintenance = new Maintenance
            {
                description = dto.Description,
                endDate = dto.EndDate,
                boatId = dto.BoatId,

              
                startDate = DateTime.Now
            };


            repo.AddMaintenance(maintenance);
        }



        // Delete Maintenance
        public bool DeleteMaintenance(int maintenanceId)
        {
            return repo.DeleteMaintenance(maintenanceId);
        }
    }
}