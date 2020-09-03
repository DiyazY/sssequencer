using SimpleInjector;
using sss_second;
using System;
using System.Reflection;

namespace TestDecoratorApproach
{
    class Program
    {
        private static readonly Container _container;
        static Program()
        {
            _container = new Container();

            Assembly currentAssem = Assembly.GetExecutingAssembly();

            _container.Register(typeof(ICommandHandler<,>), currentAssem);
            _container.RegisterDecorator(typeof(ICommandHandler<,>), typeof(LoggerDecorator<,>), Lifestyle.Transient);
            _container.RegisterDecorator(typeof(ICommandHandler<,>), typeof(ValidationDecorator<,>), Lifestyle.Transient);

            _container.Verify();
        }
        static void Main(string[] args)
        {
            var command = new SayBeepCommand();
            var service = _container.GetInstance<ICommandHandler<SayBeepCommand, Result<BeepReport, Exception>>>();

            //var t = new ValidationDecorator<SayBeepCommand, Result<BeepReport, Exception>>(
            //    new LoggerDecorator<SayBeepCommand, Result<BeepReport, Exception>>(
            //        service
            //        ));

            service.Handle(command);
        }
    }
}
