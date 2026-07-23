namespace Sea_Trips_System.Models
{
    public class MaintenanceService
    {
        private MaintenanceRepo repo;
    
       public MaintenanceService(MaintenanceRepo _repo)
        {
            repo = _repo;
        }

        public List<MaintenanceAllOutputDTO> GetAllMaintenance()
        {
            return repo.GetAllMaintenance()
                       .Select(Maintenance => new MaintenanceAllOutputDTO
                       {
                           description = Maintenance.description,
                           startDate = Maintenance.startDate,
                           maintenanceId = Maintenance.maintenanceId
                       })
                       .ToList();
        }

    }
}