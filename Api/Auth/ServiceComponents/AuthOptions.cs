using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Auth.ServiceComponents
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServer";
        public const string AUDIENCE = "AuthClient";
        public const string KEY = "2ba83013-4658-4e03-b8cc-7c0e82c927af";
        public const int LIFETIME = 120; // minutes
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
