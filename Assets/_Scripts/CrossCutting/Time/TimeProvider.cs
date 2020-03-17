using System;

namespace TT_Shooter_2d.CrossCutting.Time
{
    public abstract class TimeProvider
    {
        private static TimeProvider current;
        static TimeProvider()
        {
            TimeProvider.current = new DefaultTimeProvider();
        }
        public static TimeProvider Current
        {
            get { return TimeProvider.current; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                TimeProvider.current = value;
            }
        }
        public abstract DateTime Now { get; }
        public static void ResetToDefault()
        {
            TimeProvider.current = new DefaultTimeProvider();
        }
    }
}
