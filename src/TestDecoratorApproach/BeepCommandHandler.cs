using sss_second;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDecoratorApproach
{
    public class BeepCommandHandler : ICommandHandler<SayBeepCommand, Result<BeepReport, Exception>>
    {
        public Result<BeepReport, Exception> Handle(SayBeepCommand input)
        {
            var result = input.Execute();
            result.Match<bool>((BeepReport report) =>
            {
                Console.WriteLine("Success");
                return true;
            },
            (Exception) =>
            {
                Console.WriteLine("failure");
                return false;
            });

            return result;
        }
    }
}
