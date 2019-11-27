using System;
using JwtApi.Models;
using JwtApi.Services.Interfaces;
using Trivial.Security;

namespace JwtApi.Services
{
    /// <summary>
    /// A JSON Web Token API service implementation
    /// </summary>
    public class JwtService : IJwtService
    {
        /// <summary>
        /// Creates a base64-encoded JSON Web Token from a payload model.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>base64-encoded JWT</returns>
        public string Encode(JwtPayload payload)
        {
            var jwt = new JsonWebToken<JwtPayload>(payload, Signature());
            return jwt.ToEncodedString();
        }

        /// <summary>
        /// Parses a base64-encoded JSON Web Token into a payload model.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Payload model</returns>
        public JsonWebToken<JwtPayload> Decode(string token)
        {
            return JsonWebToken<JwtPayload>.Parse(token, Signature());
        }

        /// <summary>
        /// Creates a hash signature.
        /// </summary>
        /// <returns>HashSignatureProvider created from non-null environment value of "JWT_SECRET", or literal "secret"</returns>
        private HashSignatureProvider Signature()
        {
            var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
            return HashSignatureProvider.CreateHS256(secret ?? "secret");
        }
    }
}