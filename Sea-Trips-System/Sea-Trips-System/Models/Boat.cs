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
        public string status { get; set; } = "Available";    // default value 

        [Column(TypeName = "decimal(18,3)")]
        public decimal hourlyRate { get; set; }       //system generated 



        //one to many
        public virtual List<Appointment> Appointments { get; set; }     //Navigation Property => one boat assign to write many Appointmn 

        // reverse navigation — one Boat has many Maintenances
        public virtual List<Maintenance> Maintenances { get; set; }           // link to boat's maintenance records

    }
}
