using System;
using System.Collections.Generic;
using System.Text;

namespace TestDecoratorApproach
{
    public class BeepReport
    {
        public int Duration { get; private set; }

        public BeepReport(int duration)
        {
            Duration = duration;
        }
    }
}
