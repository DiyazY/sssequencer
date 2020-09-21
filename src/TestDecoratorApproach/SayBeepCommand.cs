using sss_second;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDecoratorApproach
{
    public class SayBeepCommand : ICommand<Result<BeepReport, Exception>>
    {
        private string _parameter;

        private SayBeepCommand() { }
        public SayBeepCommand(string parameter)
        {
            _parameter = parameter;
        }

        public Result<BeepReport, Exception> Execute()
        {
            try
            {
                Console.WriteLine($"I say: {_parameter}");

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
