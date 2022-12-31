using CatsyOnlineStore.BAL.Services;
using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CatsyOnlineStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ICustomerBAL customerRepository;
        IConfiguration _configuration;
        public LoginController(ICustomerBAL customerRepository, IConfiguration configuration)
        {
            this.customerRepository = customerRepository;
            this._configuration = configuration;
        }
        [HttpGet]
        public async Task<ActionResult> Login(UserLoginEntity user)
        {
            try
            {
                var result = await customerRepository.Login(user);
                if (result != null)
                {
                    return Ok(GenerateJwtToken(result));
                }
                return StatusCode(StatusCodes.Status401Unauthorized, "Invalid credential details");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        private string GenerateJwtToken(Customer customer)
        {
            IEnumerable<Claim> GetESignClaims(Customer customer)
            {
                List<Claim> claims = new List<Claim>();
                Claim _claim;
                _claim = new Claim("Email", customer.Email);
                claims.Add(_claim);
                _claim = new Claim("Id", customer.Id.ToString());
                claims.Add(_claim);
                return claims.AsEnumerable<Claim>();
            }

            var objSiteKeys = _configuration.GetSection("jwtTokenConfig").Get<JWTTokenEntity>();
            var key = Encoding.ASCII.GetBytes(objSiteKeys.Secret);
            var JWToken = new JwtSecurityToken(
            issuer: objSiteKeys.Issuer,
            audience: objSiteKeys.Audience,
            claims: GetESignClaims(customer),
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            return token;
        }
    }
}
