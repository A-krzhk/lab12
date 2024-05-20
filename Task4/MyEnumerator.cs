using PlantLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class MyEnumerator<T> : IEnumerator<T> where T : IInit, IComparable, ICloneable, new()
    {
        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public MyEnumerator(AVLTree<T> collection) { }

        public IEnumerable<T> InOrder(PointAVL<T>? node)
        {
            if (node != null)
            {
                foreach (T item in InOrder(node.Left))
                {
                    yield return item;
                }

                yield return node.Data;

                foreach (T item in InOrder(node.Right))
                {
                    yield return item;
                }
            }
        }

        public void Dispose() { }

        public bool MoveNext() => false;

        public void Reset() { }
    }
}
