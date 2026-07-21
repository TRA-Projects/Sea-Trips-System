using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class AppointmentStaff
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int appointmentStaffId { get; set; }    //system generated 


        // Role of this staff member in this specific trip (optional)
        [StringLength(50)]
        public string? AssignedRole { get; set; }              // user input / default (Captain, Co-Captain, Crew)


        /// ////////////////////////////////////////////////////////////////////////////////////////////

        // foreign key — bridge link to appointment
        [Required]
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }              // foreign key to appointment
        public Appointment Appointment { get; set; }        // navigation property

        // foreign key — bridge link to staff
        [Required]
        [ForeignKey("Staff")]
        public int StaffId { get; set; }                    // foreign key to staff
        public Staff Staff { get; set; }                    // navigation property

    }
}
