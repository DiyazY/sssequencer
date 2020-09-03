using System;

namespace sss_second
{
    public class ValidationDecorator<TIn, TOut> : HandlerDecoratorBase<TIn, TOut>
    {
        //protected readonly ICommandHandler<TIn, TOut> Decorated;
        public ValidationDecorator(ICommandHandler<TIn, TOut> decorated): base(decorated)
        {
            Console.WriteLine("ValidationDecorator");
        }

        public override TOut Handle(TIn input)
        {
            //some validation logic

            Console.WriteLine("Validation:)");

            return Decorated.Handle(input);
        }
    }
}
