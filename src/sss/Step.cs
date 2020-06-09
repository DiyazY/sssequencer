using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sss
{
    public class Step: IExecutable, IFinalizeable, ITraceable
    {
        private Action _finalizatorFn;
        public string Name { get; set; }
        public bool IsAsync { get; set; }
        public ITracer Tracer { get; set; }

        public Step(string name)
        {
            Name = name;
        }

        public void Execute()
        {
            var t = IsAsync ? "async" : "sync";
            Console.WriteLine($"{t} execute {Name}");
            //_tracer?.Info($"{t} execute {Name}");
            Thread.Sleep(2000);
            Console.WriteLine($"{t} execute end {Name}");
            //_tracer?.Info($"execute end {Name}");

            _finalizatorFn?.Invoke();
        }


        public Task ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Execute();
            }, cancellationToken);
        }

        IFinalizeable IFinalizeable.SetFinalizator(Action action)
        {
            _finalizatorFn = action;
            return this;
        }
    }

}
