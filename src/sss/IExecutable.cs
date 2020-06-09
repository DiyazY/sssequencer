using System;
using System.Threading;
using System.Threading.Tasks;

namespace sss
{
    public interface IExecutable
    {
        string Name { get; set; }
        bool IsAsync { get; set; }
        void Execute();

        Task ExecuteAsync(CancellationToken cancellationToken);

        //IExecutable Finalize(Action action)
        //{
        //    action.Invoke();
        //    return this;
        //}

        //IExecutable Finalize(Action<IExecutable> action)
        //{
        //    action.Invoke(this);
        //    return this;
        //}
    }
}
