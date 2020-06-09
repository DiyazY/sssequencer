using System;
using System.Collections.Generic;
using System.Text;

namespace sss
{
    public static class SequenceExtension
    {
        public static Sequence Then(this Sequence sequence, Action action)
        {
            action.Invoke();
            return sequence;
        }

        public static Sequence Finalize(this Sequence sequence, Action<Sequence> action)
        {
            action.Invoke(sequence);
            return sequence;
        }
    }
}
