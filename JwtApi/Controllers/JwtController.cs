using JwtApi.Models;
using JwtApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    /// <summary>
    /// JSON Web Token create and decode API controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        
        public JwtController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        
        /// <summary>
        /// Creates a base64-encoded JSON Web Token having a payload extracted from the passed model.'
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>base64-encoded JWT string</returns>
        [HttpPost]
        public ActionResult<string> Encode([FromBody] JwtPayload payload)
        {
            return Ok(_jwtService.Encode(payload));
        }

        /// <summary>
        /// Decodes a model from the payload of the given base64-encoded JSON Web Token
        /// </summary>
        /// <param name="token">A base64-encoded JWT</param>
        /// <returns>JwtPayload</returns>
        [HttpGet]
        public ActionResult<JwtPayload> Decode(string token)
        {
            return Ok(_jwtService.Decode(token));
        }
    }
}