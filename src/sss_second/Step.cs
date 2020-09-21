using SimpleInjector;
using System;

namespace sss_second
{
    /// <summary>
    /// Highly abstract representation of step 
    /// that uses decorator pattern in order to add additional functionality.
    /// Likewise, it depends on SimpleInjector Container class.
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class Step<TIn, TOut> : IHandler<TIn, TOut>
    {
        private readonly Container _container;
        //private readonly ICommandHandler<TIn, TOut> _command;

        public Step(Type commandHandler)
        {
            _container = new Container();
            _container.Register(typeof(ICommandHandler<TIn, TOut>), commandHandler);
        }

        public TOut Handle(TIn input)
        {
            _container.Verify();// TODO: where to place it???

            var service = _container.GetInstance<ICommandHandler<TIn, TOut>>();
            return service.Handle(input);
        }

        public void Decorate(Type type)
        {
            _container.RegisterDecorator(typeof(ICommandHandler<,>), type, Lifestyle.Transient);
        }
    }
}
