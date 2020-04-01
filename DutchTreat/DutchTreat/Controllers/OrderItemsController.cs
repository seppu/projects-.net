using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
    [Route("api/orders/{orderid}/items")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IDutchRepository repository;
        private readonly ILogger<OrderItemsController> logger;
        private readonly IMapper mapper;

        public OrderItemsController(IDutchRepository repository, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<OrderItem>> Get(int orderId)
        {
            try
            {
                var order = repository.GetOrderById(orderId);
                if (order != null) return Ok(mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get all order item: {ex}");
                return BadRequest("Failed to get all order item");
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<OrderItem>> Get(int orderId, int id)
        {
            try
            {
                var order = repository.GetOrderById(orderId);
                if (order != null)
                {
                    var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                    if (item != null) return Ok(mapper.Map<OrderItem, OrderItemViewModel>(item));
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get all order item: {ex}");
                return BadRequest("Failed to get all order item");
            }

        }
    }
}
