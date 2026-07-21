using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }           // system generated (Primary Key)

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }          // user input

        [Required]
        public string? Role { get; set; }          // user input

        [StringLength(50)]
        public string? LicenseNumber { get; set; }  // user input

        [Required]
        public bool IsAvailable { get; set; }      // system updated


        [Required]
        [StringLength(20)]
        public string? Phone { get; set; }         // user input

        

        //staff
    }
}
