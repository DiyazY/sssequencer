using sss;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ConcurrentDictionary<string, object> results = new ConcurrentDictionary<string, object>();


            var firstStep = new Step("step 1")
                .Finalize(()=> {
                    Console.WriteLine($"finalize step 1!!!");
                    results.TryAdd("step1", 1);
                });

            firstStep.IsAsync = true;


            var cts = new CancellationToken();

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            Basket basket1 = new Basket("loop1", cts);
            basket1.IsAsync = true;
            basket1.Steps
                .StartWith(firstStep)
                .Then(
                    new Step("step 2")
                        .Finalize(() => {
                            Console.WriteLine($"finalize step 2!!!");
                            results.TryAdd("step2", 2);
                        })
                )
                .Then(() =>
                {
                    var st = new Step("step 3");
                    st.IsAsync = true;
                    return st;
                });

            Basket basket2 = new Basket("loop2", cts);

            basket2.Steps
                .Add(firstStep);
            basket2.Steps
                .Add(new Step("step 2.1"));

            var st3_1 = new Step("step 3.1");
            st3_1.IsAsync = false;
            basket2.Steps
                .Add(st3_1);

            using (var seq = new Sequence("ewq"))
            {
                seq.SetTracer(new ConsoleTracer());
                seq.AddStep(basket1);
                seq.AddStep(basket2);

                while (true)
                {
                    watch.Restart();

                    seq.Run()
                        .Then(() =>
                        {
                            watch.Stop();
                            Console.WriteLine($"ticks: {watch.ElapsedMilliseconds}");
                        })
                        .Then(() =>
                        {
                            Console.WriteLine($"end!!!");
                        })
                        .Finalize((seq) => {
                            Console.WriteLine($"finalize seq!!! {seq.Name}");
                        });
                }
            }
        }
    }
}
