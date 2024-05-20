using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4  
{

    public class PointAVL<T> where T : IComparable
    {
        public T? Data { get; set; }
        public PointAVL<T>? Left { get; set; }
        public PointAVL<T>? Right { get; set; }
        public int Balance { get; set; }

        public PointAVL()
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
            this.Balance = 0;
        }

        public PointAVL(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
            this.Balance = 0;
        }

        public override string ToString()
        {
            return Data == null ? "" : Data.ToString();
        }

        public int CompareTo(PointAVL<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }


}
