namespace JwtApi.Models
{
    /// <summary>
    /// A model of a JWT payload for a specific application-of-interest
    /// </summary>
    public class JwtPayload
    {
        // Standardized public claims
        public string Sub { get; set; } // Subject
        public string Iss { get; set; } // Issuer
        public string Aud { get; set; } // Audience
        public long Exp { get; set; } // Expiration time

        // Private claims
        public bool manager { get; set; }
        public bool admin { get; set; }
    }
}