using ZepteritTask.Common.Enums;

namespace ZepteritTask.Database.Entities
{
    public class Order : BaseEntity
    {
        public string ProductCode { get; set; }
        public decimal NetPrice { get; set; }
        public decimal GrosPrice { get; set; }
        public int Amount { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public virtual Store Store { get; set; }
        public int StoreId { get; set; }
    }
}