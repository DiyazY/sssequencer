using sss_second;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDecoratorApproach
{
    public class SayBeepCommand : ICommand<Result<BeepReport, Exception>>
    {
        public Result<BeepReport, Exception> Execute()
        {
            try
            {
                Console.WriteLine("I say fucking beeep");

                var report = new BeepReport(DateTime.Now.Second);

                return new Result<BeepReport, Exception>(report);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ooops! Some failure!");
                return new Result<BeepReport, Exception>(ex);
            }
        }
    }
}
