using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExpenseTracker.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdClaim, out var userId))
            {
                throw new InvalidOperationException(
                    "Authenticated user does not have a valid ID");
            }
            return userId;
        }

        public static bool GetIsPremium(this ClaimsPrincipal user)
        {
            var isPremiumClaim = user.FindFirstValue("isPremium");



            if (!bool.TryParse(isPremiumClaim, out var isPremium))
            {
                throw new InvalidOperationException(
                    "Authenticated user does not have a valid permission");
            }
            return isPremium;
        }
    }
}
