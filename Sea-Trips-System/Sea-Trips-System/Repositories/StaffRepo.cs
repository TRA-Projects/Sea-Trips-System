namespace Sea_Trips_System.Models
{
    public class StaffRepo
    {
        private SeaTripsContext context;
        public StaffRepo (SeaTripsContext _context)
        {
            context = _context;
        }

        // 1. Get all staff

        public List<Staff> GetAll()
        {
            return context.Staffs.ToList();
        }


    }
}
