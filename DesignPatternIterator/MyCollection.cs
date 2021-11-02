using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternIterator
{
    class MyCollection<T> : IEnumerable<T>
    {
        List<T> data;

        public MyCollection(params T[] data)
        {
            this.data = new List<T>(data);
        }

        public IEnumerator<T> GetEnumerator()
        {
            // iteration forward
            foreach (T item in data)
            {
                yield return item;
            }

            //// iteration backward
            //int readIndex = data.Count;
            //while (readIndex > 0)
            //{
            //    yield return data[--readIndex];
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
