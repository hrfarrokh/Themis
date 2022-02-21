#nullable disable

namespace Themis.Application.Persistance
{
    public class AuditEntity
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
