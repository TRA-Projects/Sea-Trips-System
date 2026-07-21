using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    [Table("User")]
    public class Client
    {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generated
            public int clientId { get; set; }    //system generated 

            [Required]
            [MaxLength(100)]
            public string fullName { get; set; }   //user input

            [Required]
            [MaxLength(20)]
            public string phone { get; set; }    //user input

            [MaxLength(100)]
            public string email { get; set; }  //user input ---

            [Required]
            public DateTime createdAt { get; set; }   ////system generated 

        }
    }
