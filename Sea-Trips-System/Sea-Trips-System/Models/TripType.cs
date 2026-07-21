using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    public class TripType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //// Auto Increment (Identity)
        public int TripTypeId { get; set; } // // Primary Key

        [Required(ErrorMessage = "Trip Type Name is required.")] //  // This field is required (cannot be null)
        [StringLength(100)]  ///// Maximum length is 100 characters
        public string TypeName { get; set; }

        [Required(ErrorMessage = "Base Price is required.")]  ///// This field is required
        [Range(1, 999, ErrorMessage = "Base Price must be greater than 0.")] // // Value must be between 1 and 999
        [Column(TypeName = "decimal(18,2)")]  //  // Save as decimal(18,2) in SQL Server
        public decimal BasePrice { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")] // // Maximum length is 500 characters
        public string Description { get; set; }
    }
}

    
