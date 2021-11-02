using System.Collections;
using System.Collections.Generic;

namespace DesignPatternIterator
{
    internal class ForwardEnumerator<T> : IEnumerator<T>
    {
        private T[] t;
        int idx = -1;

        public ForwardEnumerator(T[] t)
        {
            this.t = t;
        }

        public T Current => this.t[this.idx];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
            // nothing to do
        }

        public bool MoveNext()
        {
            this.idx++;
            return this.idx < this.t.Length;
        }

        public void Reset()
        {
            this.idx = -1;
        }
    }
}