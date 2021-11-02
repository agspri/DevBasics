using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternIterator
{
    class MyClassicCollection<T> : IEnumerable<T>
    {
        List<T> data;

        public MyClassicCollection(params T[] data)
        {
            this.data = new List<T>(data);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ForwardEnumerator<T>(this.data.ToArray());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
