using System;
using System.Collections.Generic;
using System.Text;

namespace sss
{
    public static class IExecutableExtension
    {
        public static List<IExecutable> StartWith(this List<IExecutable> steps, IExecutable newSTep)
        {
            steps.Add(newSTep);
            return steps;
        }

        public static List<IExecutable> Then(this List<IExecutable> steps, IExecutable newSTep)
        {
            steps.Add(newSTep);
            return steps;
        }

        public static List<IExecutable> Then(this List<IExecutable> steps, Func<IExecutable> function)
        {
            steps.Add(function());
            return steps;
        }

        //TODO : it show throw an error at compile time!!!
        public static IExecutable Finalize(this IExecutable step, Action action)
        {
            if(!(step is IFinalizeable))
            {
                throw new Exception("Step should be finalizeable");
            }
            var finalizeableStep = step as IFinalizeable;
            finalizeableStep.SetFinalizator(action);
            return step;
        }
    }
}
