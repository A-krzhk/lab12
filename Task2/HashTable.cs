using PlantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2  
{
    public class HashTable<K, T> where T : IInit, IComparable, new() where K : IInit, IComparable, new()
    {
        T[] table; // создание самой таблицы
        K[] keys;
        int count = 0; //текущее количество записей
        double fillRatio = 0.72; //коэф заполненности таблицы
        public bool[] WasRemoved; //массив из булевых функций, для поиска в таблице, после удаления элемента

        public int Capacity => table.Length; //Сколько памяти выделено на таблицу
        public int Count => count; //получение количества записей в таблице

        //Конструктор
        public HashTable(int size = 10, double fillRatio = 0.72)
        {
            table = new T[size];
            keys = new K[size];

            WasRemoved = new bool[size];
            this.fillRatio = fillRatio;
        }

        public void Print()
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Ключ: {keys[i]}, \nзначение: {table[i]}\n");

            }
        }

        public int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode()) % Capacity;
        }



        void AddData(K key, T data)
        {
            if (data == null) return; // чтобы не добавлять пустой элемент
            int index = GetIndex(key); //Вычисляем хеш код для позиции
            int current = index; //запоминаем индекс
            if (table[index] != null) //Позиция уже занята
            {
                //Ищем свободное место до конца таблицы
                while (current < table.Length && table[current] != null)
                {
                    current++;
                }

                // Если таблица закончилась, а места нет, то идем с начала таблицы
                if (current == table.Length)
                {
                    current = 0;
                    while (current < index && table[current] != null)
                    {
                        current++;
                    }
                    // Проверяем, что current не выходит за пределы массива
                    if (current >= table.Length)
                    {
                        throw new Exception("ERROR: в таблице нет места.");
                    }
                }
            }
            table[current] = data;
            keys[current] = key;
            count++;

        }


        public int FindItem(K key)
        {
            int index = GetIndex(key);
            
            if (keys[index] == null && !WasRemoved[index]) return -1;
            else if (keys[index] != null && keys[index].Equals(key))
                return index;
            else
            {
                int current = index;
                while (current < keys.Length)
                {
                    if (keys[current] != null && keys[current].Equals(key))
                        return current;
                    current++;
                }
                current = 0;
                while (current <= index)
                {
                    if (keys[current] != null && keys[current].Equals(key))
                        return current;
                    current++;
                }

                return -1;
            }
        }


        public bool Contains (K key)
        {
            return (FindItem(key) > 0);
        }


        public bool RemoveData(K key )
        {
            int index = FindItem(key);
            if (index < 0) return false;
            count--;
            table[index] = default;
            keys[index] = default;
            WasRemoved[index] = true;
            return true;
        }


        public void AddItem(K key, T item)
        {
            if ((double)Count / Capacity > fillRatio) //Если место в таблице закончилось
            {
                //увеличиваем таблицу в 2 раза, и переписываем всю хеш таблицу
                T[] temp = (T[])table.Clone();
                K[] tempKeys = (K[])keys.Clone();
                table = new T[temp.Length * 2];
                keys = new K[temp.Length * 2];
                count = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    AddData(tempKeys[i], temp[i]);
                }

                //Увеличиваем в два раза массив с булевыми значениями
                bool[] tempWasRemoved = new bool[WasRemoved.Length];
                for (int i = 0; i < WasRemoved.Length; i++)
                {
                    tempWasRemoved[i] = WasRemoved[i];
                }

                WasRemoved = new bool[tempWasRemoved.Length * 2];

                for (int i = 0; i < tempWasRemoved.Length; i++)
                {
                    WasRemoved[i] = tempWasRemoved[i];
                }
            }

            AddData(key, item);
        }

    }

}
