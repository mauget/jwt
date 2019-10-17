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
        public string Exp { get; set; } // Expiration time

        // Private stuff
        public string ClaimA { get; set; }
        public string ClaimB { get; set; }
    }
}