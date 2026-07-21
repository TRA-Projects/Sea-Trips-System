using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ReviewId { get; set; } //system generated

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; } //user input ///

        [MaxLength(1000)]
        public string? Comment { get; set; }//user input //optional//
    }
}
