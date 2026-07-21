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



        /// ////////////////////////////////////////////////////////////////////////////////////////////

        // foreign key — every appointment must belong to exactly one client:

        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }                   
        public Client Client { get; set; }                   // navigation property

        // foreign key — every appointment must belong to exactly one boat:

        [Required]
        [ForeignKey("Boat")]
        public int BoatId { get; set; }                      // chosen from available boats
        public Boat Boat { get; set; }                       // navigation property


        // foreign key — every appointment must belong to exactly one trip type
        [Required]
        [ForeignKey("TripType")]
        public int TripTypeId { get; set; }                  // chosen from trip types list
        public TripType TripType { get; set; }               // navigation property

        // foreign key — every appointment must belong to exactly one destination
        [Required]
        [ForeignKey("Destination")]
        public int DestinationId { get; set; }               // chosen from destinations list
        public Destination Destination { get; set; }         // navigation property

        // foreign key — optional event discount
        [ForeignKey("Event")]
        public int? EventId { get; set; }                    // optional event selection
        public Event Event { get; set; }                     // navigation property

        // reverse navigation — one Appointment has many AppointmentStaffs(bridge table)
         public virtual List<AppointmentStaff> AppointmentStaffs { get; set; }

         public virtual List<Review> Reviews { get; set; }

    }
}
