using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.Models
{
    public class AppointmentStaff
    {
        [Required]
        public int appointmentId { get; set; }   // user input

        [Required]
        public int staffId { get; set; }         // user input

    }
}
