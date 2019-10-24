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
        /// Creates a signed base64-url-encoded JSON Web Token having a payload extracted from the passed JwtPayload.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Jwt
        ///     {
        ///        "sub": "JWT Demo",
        ///        "iss": "lem",
        ///        "aud": "Developers",
        ///        "exp": "1571942604066",
        ///        "manager": "false",
        ///        "admin": "true"
        ///     }
        ///
        /// </remarks>
        /// <param name="jwtPayload"></param>
        /// <returns>base64-url-encoded JWT string</returns>
        [HttpPost]
        public ActionResult<string> Encode([FromBody] JwtPayload jwtPayload)
        {
            return Ok(_jwtService.Encode(jwtPayload));
        }

        /// <summary>
        /// Decodes a model from the payload of a signed base64-url-encoded JSON Web Token
        /// </summary>
        /// <param name="token">A base64-url-encoded JWT</param>
        /// <returns>JwtPayload</returns>
        [HttpGet]
        public ActionResult<JwtPayload> Decode(string token)
        {
            return Ok(_jwtService.Decode(token));
        }
    }
}