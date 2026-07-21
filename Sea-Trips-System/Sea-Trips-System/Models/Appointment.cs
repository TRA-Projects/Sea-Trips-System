using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class Appointment
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AppointmentId { get; set; }  // system generated (Primary Key) 

        [Required]
        public int ClientId { get; set; }      // user input (Foreign Key)

        [Required]
        public int BoatId { get; set; }         //user input (Foreign Key)

        [Required]
        public int TripTypeId { get; set; }      //user input (Foreign Key)

        [Required]
        public int DestinationId { get; set; }  // user input (Foreign Key)

        public int? EventId { get; set; }  //Foreign Key

        [Required]
        public DateTime StartTime { get; set; }  // user input

        [Required]
        public DateTime EndTime { get; set; } // user input

        [Required]
        [StringLength(20)]
        public string BookingStatus { get; set; } = "Pending";

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } //system calculated

        [Required]
        public int NumberOfPeople { get; set; }  //user input

    }  
}
