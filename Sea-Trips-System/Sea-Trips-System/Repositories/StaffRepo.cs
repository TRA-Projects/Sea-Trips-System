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

        // 2. Get staff by ID
        public Staff? GetById(int id)
        {
            return context.Staffs.FirstOrDefault(s => s.staffId == id);
        }

        // 3. Add new staff

        public void Add(Staff staff)
        {
            context.Staffs.Add(staff);
            context.SaveChanges();
        }




    }
}
