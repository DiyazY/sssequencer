using System;
using System.Collections.Generic;
using System.Text;

namespace TestDecoratorApproach
{
    public class BeepReport
    {
        public readonly int Duration;

        public BeepReport(int duration)
        {
            Duration = duration;
        }
    }
}
