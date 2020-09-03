using System;
using System.Collections.Generic;
using System.Text;

namespace sss_second
{
    //public abstract class HandlerDecoratorBase<TIn, TOut>
    //{
    //    protected readonly IHandler<TIn, TOut> Decorated;
    //    protected HandlerDecoratorBase(IHandler<TIn, TOut> decorated)
    //    {
    //        Decorated = decorated;
    //    }
    //    public abstract TOut Handler(TIn input);
    //}

    public abstract class HandlerDecoratorBase<TIn, TOut> : ICommandHandler<TIn, TOut>
    {
        protected readonly ICommandHandler<TIn, TOut> Decorated;
        protected HandlerDecoratorBase(ICommandHandler<TIn, TOut> decorated)
        {
            Decorated = decorated;
        }
        public abstract TOut Handle(TIn input);
    }
}
