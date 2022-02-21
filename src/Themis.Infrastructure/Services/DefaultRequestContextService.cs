using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http;
using Themis.Application;

namespace Themis.Infrastructure.Services
{
    public class DefaultRequestContextService : IRequestContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DefaultRequestContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = Guard.Against.Null(httpContextAccessor);
        }

        public Guid GetUserId()
        {
            return Guid.NewGuid();
        }

        public string GetUsername()
        {
            return "user@gmail.com";
        }
    }
}
