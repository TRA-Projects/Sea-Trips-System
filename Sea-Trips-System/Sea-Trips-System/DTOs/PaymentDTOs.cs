namespace Sea_Trips_System.Models
{
    public class PaymentDTOs
    {
        public class PaymentOutputDTOs
        {
            public string paymentMethod { get; set; }
            public int paymentId { get; set; }
            public decimal amountPaid { get; set; }
        }
    }
}
