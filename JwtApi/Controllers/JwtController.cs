using System;
using JwtApi.Models;
using JwtApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
        /// Creates a signed base64-url-encoded JSON Web Token having a payload model extracted from the
        /// passed JwtPayload.
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
        [Consumes("application/json")]
        [Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public ActionResult<string> Encode([FromBody] JwtPayload jwtPayload)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, _jwtService.Encode(jwtPayload));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, exception.Message);
            }
        }

        /// <summary>
        /// Decodes a model from the payload model of a signed base64-url-encoded JSON Web Token
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Jwt?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBdWQiOiJEZXZlbG9wZXJzIiwiRXhwIjoxNTcxOTQyNjA0MDY2LCJJc3MiOiJsZW0iLCJTdWIiOiJKV1QgRGVtbyIsImFkbWluIjp0cnVlLCJtYW5hZ2VyIjpmYWxzZX0.TiVeUg9RVd9V7vjMd9ORdon53HsiG4GfrLk7VGYupfY
        ///
        /// </remarks>
        /// <param name="token">A base64-url-encoded JWT</param>
        /// <returns>JwtPayload</returns>
        [HttpGet]
        [Consumes("text/plain")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public ActionResult<JwtPayload> Decode(string token)
        {
            try
            {
                return Ok(_jwtService.Decode(token));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, exception.Message);
            }
        }
    }
}