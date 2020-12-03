using ZepteritTask.Common.Enums;

namespace ZepteritTask.Repository.Models
{
    public class OrderSummary
    {
        public int Amount { get; set; }
        public decimal GrossPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
