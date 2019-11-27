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
        /// Creates a signed base64-url-encoded JSON Web Token from a payload model
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Jwt
        ///    {
        ///        "jti": "63716c7f-aace-448e-9ff5-889e951fc190",
        ///        "iss": "LEM",
        ///        "sub": "Demo",
        ///        "aud": ["Developer, Journalist, Pundit"],
        ///        "exp": 1574821999,
        ///        "nbf": 1574821077,
        ///        "iat": 1574821060,
        ///        "manager": true,
        ///        "admin": false
        ///    }
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
        /// Extracts a payload from a signed base64-url-encoded JSON Web Token
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Jwt?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhdWQiOlsiRGV2ZWxvcGVyLCBKb3VybmFsaXN0LCBQdW5kaXQiXSwiZXhwIjoxNTc0ODIxOTk5LCJpYXQiOjE1NzQ4MjEwNjAsImlzcyI6IkxFTSIsImp0aSI6IjYzNzE2YzdmLWFhY2UtNDQ4ZS05ZmY1LTg4OWU5NTFmYzE5MCIsIm5iZiI6MTU3NDgyMTA3Nywic3ViIjoiRGVtbyIsImFkbWluIjpmYWxzZSwibWFuYWdlciI6dHJ1ZX0.8-evyGqh6VHLvv4mZ6YQ15FgbxQQtZU6JWC4UqmURfY
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