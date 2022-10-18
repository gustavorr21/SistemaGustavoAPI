using System.Security.Claims;

namespace SistemaGustavoAPI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            var aa = user.FindFirst(ClaimTypes.Name)?.ValueType;
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var aa = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
