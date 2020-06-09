using System;
using System.Collections.Generic;
using System.Text;

namespace sss
{
    public interface ITracer
    {
        void Info(string msg);
        void Error(string msg);
        void Warn(string msg);
    }
}
