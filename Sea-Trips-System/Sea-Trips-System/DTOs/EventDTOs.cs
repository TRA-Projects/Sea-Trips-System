using Sea_Trips_System.Models;

namespace Sea_Trips_System.DTOs
{

    // Used when adding a new Event
    public class EventInputDTO
    {
        public string eventName { get; set; }

        public decimal discountRate { get; set; }

        public bool isActive { get; set; }
    }



    // Used when displaying Event list
    public class EventOutputDTO
    {
        public int eventId { get; set; }

        public string eventName { get; set; }

        public decimal discountRate { get; set; }

        public bool isActive { get; set; }
    }




    // Used when displaying Event details with Appointments
    public class EventAllOutputDTO
    {
        public int eventId { get; set; }

        public string eventName { get; set; }

        public decimal discountRate { get; set; }

        public bool isActive { get; set; }


        // Relationship: One Event has many Appointments
        public List<Appointment> Appointments { get; set; }
    }

}