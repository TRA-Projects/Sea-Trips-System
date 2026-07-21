using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class Appointment
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int appointmentId { get; set; }  // system generated (Primary Key) 

        [Required]
        public int clientId { get; set; }      // user input (Foreign Key)

        [Required]
        public int boatId { get; set; }         //user input (Foreign Key)

        [Required]
        public int tripTypeId { get; set; }      //user input (Foreign Key)

        [Required]
        public int destinationId { get; set; }  // user input (Foreign Key)

        public int? eventId { get; set; }  //Foreign Key

        [Required]
        public DateTime startTime { get; set; }  // user input

        [Required]
        public DateTime endTime { get; set; } // user input

        [Required]
        [StringLength(20)]
        public string bookingStatus { get; set; } = "Pending";

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal totalPrice { get; set; } //system calculated

        [Required]
        public int numberOfPeople { get; set; }  //user input

    }
}
