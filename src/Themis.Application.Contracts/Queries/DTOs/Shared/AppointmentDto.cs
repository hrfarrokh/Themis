# nullable disable

namespace Themis.Application.Contracts
{
    public class AppointmentDto
    {
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}

