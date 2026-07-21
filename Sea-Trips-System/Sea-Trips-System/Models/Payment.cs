using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{

        [Table("Payment")]
        public class Payment
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int PaymentId { get; set; }                      // system generated

            [Required]
            [ForeignKey("Appointment")]
            public int AppointmentId { get; set; }                  //From List ,foreign key

            [Range(0.0, double.MaxValue)]
            [Column(TypeName = "decimal(18,2)")]
            [Required]
            public decimal AmountPaid { get; set; }               //Calculated

            [Required]
            public string PaymentMethod { get; set; }             //Defult Value [Cash,Card,BankTtansfer]

            [Required]
            [MaxLength(30)]
            public string PaymentStatus { get; set; } = "Paid";    //Defult Value [Paid,PartiallyPaid, Refunded]

            [Required]
            public DateTime TransactionDate { get; set; }       //System Genrated
        
    }
}
