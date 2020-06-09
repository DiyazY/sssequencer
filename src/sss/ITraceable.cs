using System;
using System.Collections.Generic;
using System.Text;

namespace sss
{
    public interface ITraceable
    {
        ITracer Tracer { get; set; }

        void SetTracer(ITracer tracer)
        {
            Tracer = tracer;
        }
    }
}
