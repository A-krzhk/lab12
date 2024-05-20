using PlantLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Task1
{
    // IInit - для датчика случайных чисел и метода инит (ввод с клавиатуры),
    // ICloneble - по заданию требуется создание копий, поэтому нужен метод клон 
    // new() - предполагается создание элементов в списке и требуется конструктор без параметра 

    public class MyList<T> where T : IInit, ICloneable, new()
    {
        Point<T>? beg = null;
        Point<T>? end = null;

        int count = 1;

        public int Count => count;

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data); // создаем блок с тремя полями, начало и конец - null, а data заполнена дсч
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public T MakeInitItem()
        {
            T data = new T();
            data.Init();
            return data;
        }

        // заполнение двусвязного списка
        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;

            if (beg != null)
            {
                beg.Previous = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }

        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);

            //если в списке больше 1 элемента
            if (end != null)
            {
                end.Next = newItem;
                newItem.Previous = end;
                end = newItem;
            }
            //Если в списке 1 элемент
            else
            {
                beg = end = newItem;
            }
            count++;
        }


        public void AddByPos(T item, int pos)
        {
            if (pos < 1 || pos > Count || (pos == Count + 1 && Count == 1))
                throw new Exception("ERROR: Position less or equal than zero, or more than amount of elements");

            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);

            // Если позиция равна 1, новый элемент добавляется в начало
            if (pos == 1)
            {
                AddToBegin(newData);
                return;
            }

            // Если позиция равна количеству элементов + 1, новый элемент добавляется в конец
            else if (pos == Count)
            {
                AddToEnd(newData);
                return;
            }
            else
            {
                Point<T>? current = beg;
                for (int i = 1; i < pos - 1; i++)
                {
                    current = current.Next;
                }

                // Вставляем новый элемент между двумя существующими элементами
                newItem.Next = current.Next;
                newItem.Previous = current;
                current.Next = newItem;
                newItem.Next.Previous = newItem;
                count++;
            }


        }


        //Удалить из списка элементы с нечетным номером (1, 3, 5 и т.д)
        public void RemoveOdd()
        {
            if (Count == 1) throw new Exception("ERROR: Tle list almost empty");
            Point<T>? current = beg;
            int index = 1;
            while (current != null)
            {
                // Удаляем текущий элемент, если его номер нечетный
                if (index % 2 == 1)
                {
                    // Если текущий элемент не является началом списка
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    // Если текущий элемент является началом списка
                    else
                        beg = current.Next;
                    // Если текущий элемент не является концом списка
                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    // Если текущий элемент является концом списка
                    else
                        end = current.Previous;

                    count--;
                }

                // Переходим к следующему элементу
                current = current.Next;
                index++;
            }
        }
        //Конструкторы:
        public MyList() { }

        public MyList(int size)
        {
            if (size <= 0) throw new Exception("ERROR: Length less than zero");
            beg = MakeRandomData();
            end = beg;
            for (int i = 0; i < size - 1; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
        }

        public MyList(T[] collection)
        {
            if (collection == null) throw new Exception("ERROR: Empty collection - null");
            if (collection.Length == 0) throw new Exception("ERROR: Emty collections - length is zero");

            T newData = (T)collection.Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 0; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList()
        {
            if (Count == 1)
                Console.WriteLine("list is empty");
            Point<T>? current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine($"{i + 1} {current}");
                current = current.Next;
            }
        }

        public MyList<T> DeepCopy()
        {
            MyList<T> newList = new MyList<T>();

            // Если список пуст, возвращаем пустую копию
            if (beg == null)
                return newList;

            // Проходим по всем элементам исходного списка и добавляем их в новый список
            Point<T>? current = beg;
            while (current != null)
            {
                T newData = (T)current.Data.Clone();
                newList.AddToEnd(newData);
                current = current.Next;
            }

            return newList;
        }

        // Удаление списка из памяти
        public void Clear()
        {
            // Устанавливаем начальный и конечный элементы списка в null,
            // чтобы список был удален из памяти
            beg = null;
            end = null;

            // Обнуляем счетчик элементов списка
            count = 1;
        }

    }


}