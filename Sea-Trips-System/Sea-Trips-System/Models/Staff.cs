using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int staffId { get; set; }           // system generated (Primary Key)

        [Required]
        [StringLength(100)]
        public string? name { get; set; }          // user input

        [Required]
        public string? role { get; set; }          // user input

        [StringLength(50)]
        public string? licenseNumber { get; set; }  // user input

        [Required]
        public bool isAvailable { get; set; }      // system updated


        [Required]
        [StringLength(20)]
        public string? phone { get; set; }         // user input


        /// ////////////////////////////////////////////////////////////////////////////////////////////

        // reverse navigation — one Staff has many AppointmentStaffs (bridge table)
        public virtual List<AppointmentStaff> AppointmentStaffs { get; set; } // bridge table link
    }
}
