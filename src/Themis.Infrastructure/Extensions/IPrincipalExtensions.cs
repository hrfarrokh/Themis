using System.Security.Principal;
using System.Security.Claims;

namespace Themis.Infrastructure
{
    public static class IPrincipalExtensions
    {
        public static Guid GetId(this IPrincipal principal)
        {
            if (principal is ClaimsPrincipal claims)
            {
                return new Guid(claims.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            throw new ArgumentException(message: "The principal must be a ClaimsPrincipal",
                                        paramName: nameof(principal));
        }
    }
}
