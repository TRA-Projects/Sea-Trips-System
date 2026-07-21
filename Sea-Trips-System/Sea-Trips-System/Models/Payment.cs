using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sea_Trips_System.Models
{

        [Table("Payment")]
        public class Payment
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int paymentId { get; set; }                      // system generated


            [Range(0.0, double.MaxValue)]
            [Column(TypeName = "decimal(18,2)")]
            [Required]
            public decimal amountPaid { get; set; }               //Calculated

            [Required]
            public string paymentMethod { get; set; }             //Defult Value [Cash,Card,BankTtansfer]

            [Required]
            [MaxLength(30)]
            public string paymentStatus { get; set; } = "Paid";    //Defult Value [Paid,PartiallyPaid, Refunded]

            [Required]
            public DateTime transactionDate { get; set; }       //System Genrated

            [Required]
            [ForeignKey("Appointment")]
            public int appointmentId { get; set; }                  //From List ,foreign key
           public Appointment Appointment { get; set; }// navication property
    }
}
