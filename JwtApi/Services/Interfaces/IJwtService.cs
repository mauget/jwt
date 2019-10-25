using JwtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Trivial.Security;

namespace JwtApi.Services.Interfaces
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