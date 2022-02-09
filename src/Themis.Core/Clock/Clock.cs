using System;

namespace Themis.Core
{
    public static class Clock
    {
        private static IClock _instance = new SystemClock();

        public static IClock Instance
        {
            get => _instance;
            set => _instance = value ?? throw new ArgumentException("Clock can not be set to null");
        }

        public static DateTimeOffset Now => _instance.Now;
    }
}
