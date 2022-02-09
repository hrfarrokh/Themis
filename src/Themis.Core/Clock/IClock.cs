using System;

namespace Themis.Core
{
    public interface IClock
    {
        DateTimeOffset Now { get; }
    }
}
