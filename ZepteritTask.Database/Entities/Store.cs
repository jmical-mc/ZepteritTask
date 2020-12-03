using System.Collections.Generic;

namespace ZepteritTask.Database.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public string StoreNumber { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}