using JwtApi.Models;
using Trivial.Security;

namespace JwtApi.Services
{
    public interface IJwtService
    {
        string Encode(JwtPayload payload);
        JsonWebToken<JwtPayload> Decode(string token);
    }
}