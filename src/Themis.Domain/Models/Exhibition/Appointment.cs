using Themis.Core.Models;

namespace Themis.Domain
{
    public class Appointment : ValueObject<Appointment>
    {
        public Appointment(DateTimeOffset from, DateTimeOffset to)
        {
            if (from >= to)
                throw new Exception("From must be less than the To.");

            From = from;
            To = to;
        }

        public DateTimeOffset From { get; }
        public DateTimeOffset To { get; }

    }
}
