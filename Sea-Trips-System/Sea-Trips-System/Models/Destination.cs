using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class Destination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DestinationId { get; set; }//system generated

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }//user input

        [MaxLength(100)]
        public string Coordinates { get; set; }//user input

        [Required]
        public TimeSpan EstimatedDuration { get; set; }//calculated
    }
}
