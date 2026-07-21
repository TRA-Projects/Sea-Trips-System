using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int reviewId { get; set; } //system generated

        [Required]
        [Range(1, 5)]
        public int rating { get; set; } //user input 

        [MaxLength(1000)]
        public string? comment { get; set; }//user input //optional

        // foreign key — every review must belong to exactly one appointment


        [Required]
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }                         // foreign key to appointment[cite: 1]
        public Appointment Appointment { get; set; }                   // navigation property
    }
}
