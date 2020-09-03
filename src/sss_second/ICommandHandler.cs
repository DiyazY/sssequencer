using System;
using System.Collections.Generic;
using System.Text;

namespace sss_second
{
    public interface ICommandHandler<in TIn, out TOut>: IHandler<TIn, TOut> 
        //where TIn: ICommand<TOut>      
    {
        //TOut Handle(TIn input);
    }
}
