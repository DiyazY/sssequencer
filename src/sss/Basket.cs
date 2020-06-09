using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace sss
{

    /// <summary>
    /// Unit of smt
    /// </summary>
    public class Basket: IExecutable
    {
        private CancellationToken _cancellationToken;
        private List<Task> _asyncSteps;

        public string Name { get; set; }
        public bool IsAsync { get; set; }
        public List<IExecutable> Steps { get; private set; } 
        public bool IsFinished { get; private set; }

        private Basket()
        {

        }

        public Basket(string name, CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _asyncSteps = new List<Task>();
            Name = name;
            Steps = new List<IExecutable>();
        }

        public void Execute()
        {
            for (int i = 0; i < Steps.Count; i++)
            {
                if (Steps[i].IsAsync)
                {
                    _asyncSteps.Add(Steps[i].ExecuteAsync(_cancellationToken));
                }
                else
                {
                    Steps[i].Execute();
                }   
            }
            Task.WaitAll(_asyncSteps.ToArray());
            IsFinished = true;
        }

        public Task ExecuteAsync()
        {
            return Task.Run(() =>
            {
                Execute();
            }, _cancellationToken);
        }

        public Task ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Execute();
            }, cancellationToken);
        }
    }

}
