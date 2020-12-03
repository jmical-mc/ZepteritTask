using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZepteritTask.Database;
using ZepteritTask.Database.Entities;
using ZepteritTask.Repository.Interfaces;
using ZepteritTask.Repository.Models;

namespace ZepteritTask.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public ZepteritTaskContenxt Contenxt { get; }

        public OrderRepository(ZepteritTaskContenxt contenxt)
        {
            Contenxt = contenxt;
        }

        public List<Order> GetOrders()
        {
            return Contenxt.Orders.FromSqlRaw(@"SELECT
       O.[Id] 
      ,O.[CreatedDate]
      ,O.[UpdatedDate]
      ,O.[StoreId]
      ,O.[ProductCode]
      ,O.[NetPrice]
      ,O.[GrosPrice]
      ,O.[Amount]
      ,O.[Street]
      ,O.[City]
      ,O.[PostCode]
      ,O.[PaymentMethod]
      ,S.[Name]
        FROM[dbo].[Orders] O
        LEFT OUTER JOIN[dbo].[Stores]  S
        ON O.StoreId = S.Id
        WHERE O.StoreId % 2 = 0 AND O.City LIKE '%w%'")
                  .AsNoTracking()
                .ToList();
        }

        public List<OrderSummary> GetSummary()
        {
            return Contenxt.Orders
                .AsNoTracking()
                .Where(w => (w.Amount * w.GrosPrice) >= 100)
                .GroupBy(g => g.PaymentMethod)
                .Select(s => new OrderSummary
                {
                    Amount = s.Sum(x => x.Amount),
                    GrossPrice = s.Sum(x => x.GrosPrice),
                    PaymentMethod = s.Key
                })
                .ToList();
        }
    }
}