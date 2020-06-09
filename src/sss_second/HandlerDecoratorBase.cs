using System;
using System.Collections.Generic;
using System.Text;

namespace sss_second
{
    public abstract class HandlerDecoratorBase<TIn, TOut> : IHandler<TIn, TOut>
    {
        protected readonly IHandler<TIn, TOut> Decorated;
        public HandlerDecoratorBase(IHandler<TIn, TOut> decorated)
        {
            Decorated = decorated;
        }
        public abstract TOut Handler(TIn input);
    }
}
