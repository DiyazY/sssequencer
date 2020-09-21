using SimpleInjector;
using sss_second;
using System;
using System.Reflection;

namespace TestDecoratorApproach
{
    class Program
    {
        //private static readonly Container _container;
        //static Program()
        //{
        //    _container = new Container();

        //    Assembly currentAssem = Assembly.GetExecutingAssembly();

        //    _container.Register(typeof(ICommandHandler<,>), currentAssem);
        //    _container.RegisterDecorator(typeof(ICommandHandler<,>), typeof(LoggerDecorator<,>), Lifestyle.Transient);
        //    _container.RegisterDecorator(typeof(ICommandHandler<,>), typeof(ValidationDecorator<,>), Lifestyle.Transient);

        //    _container.Verify();
        //}
        static void Main(string[] args)
        {
            var command = new SayBeepCommand("1st command");

            //var service = _container.GetInstance<ICommandHandler<SayBeepCommand, Result<BeepReport, Exception>>>();
            //service.Handle(command);


            var step = new Step<SayBeepCommand, Result<BeepReport, Exception>>(typeof(BeepCommandHandler));
            step.Decorate(typeof(LoggerDecorator<,>));
            step.Decorate(typeof(ValidationDecorator<,>));
            step.Handle(command);

            var step1 = new Step<SayBeepCommand, Result<BeepReport, Exception>>(typeof(BeepCommandHandler));
            step1.Decorate(typeof(LoggerDecorator<,>));
            var step1Result = step1.Handle(new SayBeepCommand("2st command"));
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(step1Result.Value).ToString()); 

        }
    }
}
