using JwtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Trivial.Security;

namespace JwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        /// <summary>
        /// Creates a base64-enboded JSON Web Token having a payload extracted from the passed model.'
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>base64-encoded JWT string</returns>
        [HttpPost]
        public ActionResult<string> Encode([FromBody] Model payload)
        {
            var sign = HashSignatureProvider.CreateHS256("ugv9pquf5b2vey2hsa");
            var jwt = new JsonWebToken<Model>(payload, sign);
            var jwtStr = jwt.ToEncodedString();
            return Ok(jwtStr);
        }

        /// <summary>
        /// Decodes a model from the payload of the given base64-encoded JSON Web Tokaen
        /// </summary>
        /// <param name="jwtStr">A JWT</param>
        /// <returns>Model</returns>
        [HttpGet]
        public ActionResult<Model> Decode(string jwtStr)
        {
            var sign = HashSignatureProvider.CreateHS256("ugv9pquf5b2vey2hsa");
            var jwt = JsonWebToken<Model>.Parse(jwtStr, sign);
            return Ok(jwt);
        }
    }
}