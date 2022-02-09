using System;

namespace Themis.Core
{
    internal class SystemClock : IClock
    {
        public DateTimeOffset Now => DateTimeOffset.UtcNow;
    }
}
