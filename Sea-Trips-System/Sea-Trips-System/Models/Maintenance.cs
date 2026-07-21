using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{
    [Table("Maintenance")]
    public class Maintenance
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int maintenanceId { get; set; }                        //System Genrated

      

        [MaxLength(1000)]
        public string description { get; set; }                     //User input

        [Required]
        public DateTime startDate { get; set; }                    //System Genrated
        public DateTime? endDate { get; set; }                    //User input

        // foreign key — every maintenance record must belong to exactly one boat
        [Required]
        [ForeignKey("Boat")]
        public int boatId { get; set; }                              //From List ,foreign key
        public Boat Boat { get; set; }                                 // navigation property
    }
}
