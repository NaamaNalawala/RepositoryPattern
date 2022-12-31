using CatsyOnlineStore.BAL.Services;
using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CatsyOnlineStore.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBAL orderRepository;
        public OrderController(IOrderBAL orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        /// <summary>
        /// Order details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            try
            {
                var result = await this.orderRepository.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        /// <summary>
        /// Order details
        /// </summary>
        /// <returns></returns>
        [HttpGet("OrdersByCustomer")]
        public async Task<ActionResult> GetOrdersByCustomer()
        {
            try
            {
                var claimValues = @User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                var result = await this.orderRepository.GetOrdersByCustomerId(claimValues);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        /// <summary>
        /// Order with product details
        /// </summary>
        /// <returns></returns>
        [HttpGet("OrdersWithProductDetails")]
        public async Task<ActionResult> GetOrdersWithProductDetails()
        {
            try
            {
                var result = await orderRepository.GetOrderWIthProductDetails();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        /// <summary>
        /// Add Order details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddOrder(Order order)
        {
            try
            {
                var result = await this.orderRepository.AddAsync(order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        /// <summary>
        /// Update Order details
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateOrder(Order order)
        {
            try
            {
                var result = await this.orderRepository.UpdateAsync(order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
