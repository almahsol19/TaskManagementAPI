using TaskManagementApi.Models;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class TokenService
    {
        // Very simple, for demo only
        public static string GenerateToken(User user)
        {
            return $"{user.Username}:{user.Role}";
        }

        public static (string Username, string Role)? ValidateToken(string token)
        {
            var parts = token.Split(':');
            if (parts.Length != 2)
                return null;
            return (parts[0], parts[1]);
        }
    }
}
