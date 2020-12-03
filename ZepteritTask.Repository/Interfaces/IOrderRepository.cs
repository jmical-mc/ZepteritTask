using System.Collections.Generic;
using ZepteritTask.Database.Entities;
using ZepteritTask.Repository.Models;

namespace ZepteritTask.Repository.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        List<OrderSummary> GetSummary();
    }
}
