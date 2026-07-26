namespace Sea_Trips_System.Models
{
    public class StaffService
    {
        private  StaffRepo staffRepo;
        public StaffService(StaffRepo _staffRepo)
        {
            staffRepo = _staffRepo;
        }


    }
}