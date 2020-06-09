using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace sss
{
    public sealed class Sequence: IDisposable
    {
        private bool _disposed;

        //private readonly ConcurrentDictionary<string, object> _results = new ConcurrentDictionary<string, object>();
        private readonly List<IExecutable> _steps = new List<IExecutable>();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly List<Task> _asyncSteps = new List<Task>();
        private ITracer _tracer;

        public string Name { get; set; }

        private Sequence()
        {

        }

        public Sequence(string name)
        {
            Name = name;
        }

        public void AddStep(IExecutable step)
        {
            CheckDisposed();
            if(_steps.Any(p=>p.Name == step.Name))
            {
                throw new Exception("Name should be unique!!!");
            }
            _steps.Add(step);
        }

        public Sequence Run()
        {
            CheckDisposed();
            
            int i = 0;
            while (!_cts.IsCancellationRequested && i < _steps.Count)
            {
                if (_steps[i].IsAsync)
                {
                    _asyncSteps.Add(_steps[i].ExecuteAsync(_cts.Token));
                }
                else
                {
                    _steps[i].Execute();
                }
                i++;
            }
            Task.WaitAll(_asyncSteps.ToArray());
            return this;
        }

        public void SetTracer(ITracer tracer)
        {
            CheckDisposed();
            _tracer = tracer;
        }

        public void Cancel()
        {
            _cts.Cancel();
        }

        #region Dispose
        /// <summary>
        /// Dispose resources.
        /// </summary>
        public void Dispose()
        {
            if (_disposed) return;
            _cts.Dispose();
            _disposed = true;
        }

        /// <summary>
        /// Check instance for existing
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Sequence");
            }
        }
        #endregion
    }
}
