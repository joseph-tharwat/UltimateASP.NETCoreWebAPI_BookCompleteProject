using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Contracts.Logger;

namespace jwtApiSimpleExample.Controllers
{
    [ApiController]
    [Route("api/simple")]
    public class SimpleController : ControllerBase
    {
        private ILoggerService _logger;
        public SimpleController(ILoggerService logger)
        {
            _logger = logger;
        }

        [HttpPost("getToken")]
        public IActionResult getToken()
        {
            _logger.LogInfo("start generating token");
            var claims = new List<Claim>();
            claims.Add(new Claim("guid", Guid.NewGuid().ToString()));

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.ToLocalTime().AddMinutes(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qazwsxedcrfvtgbyhnujmik,ol.p;/[']")),
                    SecurityAlgorithms.HmacSha256)
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();   

            _logger.LogDebuge("Token is generated"); 
            return Ok($"{tokenHandler.WriteToken(token)}    {token.ValidTo}");
        }
        
        [HttpGet("getData")]
        [Authorize]
        public IActionResult getData([FromQuery] string id)
        {
            return Ok($"Received: {id}");
        }
    }
}