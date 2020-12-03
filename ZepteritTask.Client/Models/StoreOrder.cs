using System;
using ZepteritTask.Common.Enums;

namespace ZepteritTask.Client.Models
{
    public class StoreOrder
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ProductCode { get; set; }
        public decimal NetPrice { get; set; }
        public decimal GrosPrice { get; set; }
        public int Amount { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
