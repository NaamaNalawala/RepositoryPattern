using CatsyOnlineStore.BAL.Services;
using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatsyOnlineStore.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBAL productRepository;
        public ProductController(IProductBAL productRepository)
        {
            this.productRepository = productRepository;
        }
        /// <summary>
        /// Product details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            try
            {
                var result = await this.productRepository.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        /// <summary>
        /// Add Product details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            try
            {
                var result = await this.productRepository.AddAsync(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        /// <summary>
        /// Update Product details
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            try
            {
                var result = await this.productRepository.UpdateAsync(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
