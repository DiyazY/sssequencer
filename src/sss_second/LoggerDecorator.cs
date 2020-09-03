using System;
using System.Collections.Generic;
using System.Text;

namespace sss_second
{

    public class LoggerDecorator<TIn, TOut> : HandlerDecoratorBase<TIn, TOut>
    {
        public LoggerDecorator(ICommandHandler<TIn, TOut> decorated): base(decorated)
        {
        }

        public override TOut Handle(TIn input)
        {
            //some validation logic
            Console.WriteLine("Logger start");
            Console.WriteLine(input);

            var output = Decorated.Handle(input);

            Console.WriteLine(output);
            Console.WriteLine("Logger end");
            return output;
        }
    }
}
