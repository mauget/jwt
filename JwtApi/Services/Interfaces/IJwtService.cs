using JwtApi.Models;
using Trivial.Security;

namespace JwtApi.Services
{
    /// <summary>
    /// A JSON Web Token API service
    /// </summary>
    public interface IJwtService
    {
        string Encode(JwtPayload payload);
        JsonWebToken<JwtPayload> Decode(string token);
    }
}