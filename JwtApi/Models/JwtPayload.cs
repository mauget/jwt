using System.Runtime.Serialization;
using Trivial.Security;

namespace JwtApi.Models
{
    /// <summary>
    /// A model of a JWT payload for a specific application-of-interest
    ///
    /// --------------
    /// Comments contributed by gitHub member https://github.com/kingcean:
    /// a. The type of expiration claim (exp) and other date type claims is Unix timestamp;
    /// b. The audience claim (aud) supports case-sensitive string array of one or more audience identifiers;
    /// c. Also contain claims JWT ID (jti), available start time (nbf), issue creation time (iat), etc.
    /// ---------------
    /// JsonWebTokenPayLoad declares optional standard payload RFC 7519 claim items.
    /// We add claims as well. We define "manager" and "admin" boolean private claimss.
    /// 
    /// Workable example JSON for this payload model:
    ///
    ///    {
    ///      "jti": "63716c7f-aace-448e-9ff5-889e951fc190",
    ///      "iss": "LEM",
    ///      "sub": "Demo",
    ///      "aud": ["Developer, Journalist, Pundit"],
    ///      "exp": 1574821999,
    ///      "nbf": 1574821077,
    ///      "iat": 1574821060,
    ///      "manager": true,
    ///      "admin": false
    ///    }
    /// 
    /// </summary>
    [DataContract]
    public class JwtPayload : JsonWebTokenPayload
    {
        // Private claims.
        // (Annotations properly map boolean 'Is' members to JWT claim names)
        
        [DataMember(Name = "admin")]
        public bool IsAdmin { get; set; }
        
        [DataMember(Name = "manager")]
        public bool IsManager { get; set; }
    }
}