using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZepteritTask.Database.Entities;
using ZepteritTask.Repository.Interfaces;

namespace ZepteritTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderRepository.GetOrders();

            return Ok(orders);
        }

        [HttpGet("summary")]
        public IActionResult GetSummary()
        {
            var ordersSummary = _orderRepository.GetSummary();

            return Ok(ordersSummary);
        }
    }
}