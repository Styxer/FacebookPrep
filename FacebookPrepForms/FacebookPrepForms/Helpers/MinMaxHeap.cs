﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Helpers
{
    public class MaxHeap<T> : IEnumerable<T>
    {
        private MinHeap<T> minHeap;

        public MaxHeap(IEnumerable<T> items, IComparer<T> comparer)
        {
            var negatedComparer = Comparer<T>.Create((x, y) => comparer.Compare(y, x));
            minHeap = new MinHeap<T>(items, negatedComparer);
        }

        public MaxHeap(IEnumerable<T> items) : this(items, Comparer<T>.Default) { }

        public MaxHeap(IComparer<T> comparer) : this(new T[0], comparer) { }

        public MaxHeap() : this(Comparer<T>.Default) { }

        public int Count => minHeap.Count;

        public T Max => minHeap.Min;

        /// <summary>
        /// Extract the largest element.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public T ExtractMax() => minHeap.ExtractMin();

        /// <summary>
        /// Insert the value.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Add(T item) => minHeap.Add(item);

        public IEnumerator<T> GetEnumerator() => minHeap.GetEnumerator();

        //IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}