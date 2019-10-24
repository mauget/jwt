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
        /// </summary>        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Jwt?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBdWQiOiJEZXZlbG9wZXJzIiwiRXhwIjoxNTcxOTQyNjA0MDY2LCJJc3MiOiJsZW0iLCJTdWIiOiJKV1QgRGVtbyIsImFkbWluIjp0cnVlLCJtYW5hZ2VyIjpmYWxzZX0.TiVeUg9RVd9V7vjMd9ORdon53HsiG4GfrLk7VGYupfY
        ///
        /// </remarks>
        /// <param name="token">A base64-url-encoded JWT</param>
        /// <returns>JwtPayload</returns>
        [HttpGet]
        public ActionResult<JwtPayload> Decode(string token)
        {
            return Ok(_jwtService.Decode(token));
        }
    }
}