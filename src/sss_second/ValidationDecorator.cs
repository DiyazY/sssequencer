using System;

namespace sss_second
{
    public class ValidationDecorator : HandlerDecoratorBase<int, int>
    {
        public ValidationDecorator(IHandler<int, int> decorated) : base(decorated)
        {

        }
        public override int Handler(int input)
        {
            return Decorated.Handler(input);
        }
    }
}
