using System;

namespace TT_Shooter_2d.CrossCutting.Time
{
    class DefaultTimeProvider : TimeProvider
    {
        public override DateTime Now => DateTime.Now;
    }
}
