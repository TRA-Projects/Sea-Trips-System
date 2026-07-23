namespace Sea_Trips_System.Models
{
    public class MaintenanceRepo
    {
        private SeaTripsContext context;
        public MaintenanceRepo(SeaTripsContext _context)
        {
            context = _context;
        }


        public  List<Maintenance> GetAllMaintenance()
        {
            return context.Maintenances.ToList();
        }
    }
}
