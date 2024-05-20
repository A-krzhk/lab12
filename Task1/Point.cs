using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Point<T>
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Previous { get; set; }

        public Point()
        {
            this.Data = default(T); // для присвоения ссылочным типам null, а типам значений 0
            this.Next = null;
            this.Previous = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Previous = null;
        }

        //String - ссылочный тип, поэтому проверяем на null
        public override string? ToString()
        {
            return Data == null ? "" : Data.ToString();
        }

        //int - возвращает либо 0 либо 1, поэтому не добавляем "?" 
        public override int GetHashCode()
        {
            return Data == null ? 0 : Data.GetHashCode();
        }
    }
}