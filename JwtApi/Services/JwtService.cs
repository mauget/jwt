using JwtApi.Models;
using Trivial.Security;

namespace JwtApi.Services
{
    public class JwtService : IJwtService
    {
        public string Encode(JwtPayload payload)
        {
            var sign = HashSignatureProvider.CreateHS256("ugv9pquf5b2vey2hsa");
            var jwt = new JsonWebToken<JwtPayload>(payload, sign);
            return jwt.ToEncodedString();
        }

        public JsonWebToken<JwtPayload> Decode(string token)
        {
            var sign = HashSignatureProvider.CreateHS256("ugv9pquf5b2vey2hsa");
            return JsonWebToken<JwtPayload>.Parse(token, sign);
        }
    }
}