#nullable disable

namespace Themis.Application.Persistance
{
    public class AppointmentEntity
    {
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}
