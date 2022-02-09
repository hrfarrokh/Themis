#nullable disable

namespace Themis.Application.Contracts.Persistance
{
    public class AppointmentEntity
    {
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}
