# nullable disable

namespace Themis.Application.Contracts
{
    public class AuditDto
    {
        public string Username { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}

