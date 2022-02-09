#nullable disable

namespace Themis.Application.Contracts.Persistance
{
    public class AuditEntity
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
