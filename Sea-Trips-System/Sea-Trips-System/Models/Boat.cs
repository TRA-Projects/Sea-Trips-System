using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    [Table("Boat")]
    [Index(nameof(boatName), IsUnique = true)]  //uniqe
    public class Boat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generated
        public int boatId { get; set; }     //system generated 

        [Required]
        [MaxLength(50)]
        public string boatName { get; set; }   // user input

        [Required]
        public int capacity { get; set; }   // user input

        [Required(ErrorMessage = "Status is required.")]
        public string status { get; set; }     // default value 

        [Column(TypeName = "decimal(18,3)")]
        public decimal hourlyRate { get; set; }       //system generated 


    }
}
