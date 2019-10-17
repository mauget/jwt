using JwtApi.Models;
using Trivial.Security;

namespace JwtApi.Services
{
    public class JwtService : IJwtService
    {
        public string Encode(JwtPayload payload)
        {
            var jwt = new JsonWebToken<JwtPayload>(payload, Sign());
            return jwt.ToEncodedString();
        }

        public JsonWebToken<JwtPayload> Decode(string token)
        {
            return JsonWebToken<JwtPayload>.Parse(token, Sign());
        }

        private HashSignatureProvider Sign()
        {
            return HashSignatureProvider.CreateHS256("ugv9pquf5b2vey2hsa");
        }
    }
}