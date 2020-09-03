using System;
using System.Collections.Generic;
using System.Text;

namespace sss_second
{
    public interface ICommand<out TOut>
    {
        TOut Execute();
    }
}
