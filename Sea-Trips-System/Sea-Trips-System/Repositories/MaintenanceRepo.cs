namespace Sea_Trips_System.Models
{
    public class MaintenanceRepo
    {
        private SeaTripsContext context;

        //Constructor
        public MaintenanceRepo(SeaTripsContext _context)
        {
            context = _context;
        }


        // View All Maintenances 
        public List<Maintenance> GetAllMaintenance()
        {
            return context.Maintenances.ToList();
        }



        // Add Maintenance
        public void AddMaintenance(Maintenance maintenance)
        {
            context.Maintenances.Add(maintenance);
            context.SaveChanges();
        }



        // Delete Maintenance
        public bool DeleteMaintenance(int maintenanceId)
        {
            var maintenance = context.Maintenances
                                    .FirstOrDefault(m => m.maintenanceId == maintenanceId);

            if (maintenance == null)
            {
                return false;
            }

            context.Maintenances.Remove(maintenance);
            context.SaveChanges();

            return true;
        }
    }
}