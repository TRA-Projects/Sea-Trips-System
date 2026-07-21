using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class AppointmentStaff
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int appointmentStaffId { get; set; }    //system generated 

        [Required]
        public int appointmentId { get; set; }   // user input

        [Required]
        public int staffId { get; set; }         // user input

    }
}
