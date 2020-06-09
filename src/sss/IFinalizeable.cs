using System;
using System.Collections.Generic;
using System.Text;

namespace sss
{
    public interface IFinalizeable
    {
        IFinalizeable SetFinalizator(Action action);
    }
}
