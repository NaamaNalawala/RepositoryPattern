using CatsyOnlineStore.BAL.Services;
using CatsyOnlineStore.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatsyOnlineStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        ICustomerBAL _customerRepository;
        public CustomerController(ICustomerBAL customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        /// <summary>
        /// Customer details
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            try
            {
                var result = await this._customerRepository.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        /// <summary>
        /// Add Customer details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer customer)
        {
            try
            {
                var result = await _customerRepository.AddAsync(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        /// <summary>
        /// Add Customer details
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {
            try
            {
                var result = await _customerRepository.UpdateAsync(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
