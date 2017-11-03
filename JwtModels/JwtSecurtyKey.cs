using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JwtTutorial.JwtModels
{
    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret) => 
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
    }
}