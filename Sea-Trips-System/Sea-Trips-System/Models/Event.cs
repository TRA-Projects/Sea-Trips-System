using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class Event
    {
        [Key] // Primary Key (PK)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto Increment (Identity)
        public int EventId { get; set; }

        // Required field
        // Max length = 100
        [Required]
        [StringLength(100)]
        public string EventName { get; set; }  // User input

        // Database Type: decimal(5,2)
        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountRate { get; set; } //user input

        // User selects whether the event is active
        [Required]
        public bool IsActive { get; set; }
    
}
}
