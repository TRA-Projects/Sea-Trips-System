using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class Destination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int destinationId { get; set; }//system generated

        [Required]
        [MaxLength(100)]
        public string name { get; set; }//user input

        [MaxLength(100)]
        public string coordinates { get; set; }//user input

        [Required]
        public TimeSpan estimatedDuration { get; set; }//calculated

        // reverse navigation — one Destination has many Appointments
        public virtual List<Appointment> Appointments { get; set; }           // link to destination bookings
    }
}
