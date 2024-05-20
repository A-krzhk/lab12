using PlantLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Activity;

namespace Task4
{

    // Класс для представления AVL-дерева
    public class AVLTree<T> : IEnumerable<T>, ICollection<T> where T : IInit, IComparable, ICloneable, new()
    {
        public PointAVL<T> root = null;

        int count = 0;
        public int Count => count;

        public bool IsReadOnly => throw new NotImplementedException();

        public AVLTree() { }

        public AVLTree(int length)
        {
            count = length;
            T data = new T();
            for (int i = 0; i < length; i++)
            {
                data.RandomInit();
                Add(data);
                data = new T();
            }
        }

        public AVLTree(AVLTree<T> collection)
        {
            foreach (T item in collection)
            {
                this.Add((T)item.Clone());
            }
        }

        void Show(PointAVL<T> point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine($"{point.Data} \n");
                Show(point.Right, spaces + 5);
            }
        }

        public void ShowTree()
        {
            Show(root);
        }

        int Height(PointAVL<T> node)
        {
            if (node == null)
                return 0;
            return Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        void SetBalance(PointAVL<T> node)
        {
            if (node != null)
                node.Balance = Height(node.Right) - Height(node.Left);
        }

        PointAVL<T> TurnLeft(PointAVL<T> node)
        {
            PointAVL<T> newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            SetBalance(node);
            SetBalance(newRoot);
            return newRoot;
        }

        PointAVL<T> TurnRight(PointAVL<T> node)
        {
            PointAVL<T> newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            SetBalance(node);
            SetBalance(newRoot);
            return newRoot;
        }

        PointAVL<T> Balance(PointAVL<T> node)
        {
            SetBalance(node);
            if (node.Balance == 2)
            {
                if (Height(node.Right.Right) >= Height(node.Right.Left))
                {
                    node = TurnLeft(node);
                }
                else
                {
                    node.Right = TurnRight(node.Right);
                    node = TurnLeft(node);
                }
            }
            else if (node.Balance == -2)
            {
                if (Height(node.Left.Left) >= Height(node.Left.Right))
                {
                    node = TurnRight(node);
                }
                else
                {
                    node.Left = TurnLeft(node.Left);
                    node = TurnRight(node);
                }
            }
            return node;
        }

        public void Insert(T data)
        {
            root = Insert(root, data);
        }

        PointAVL<T> Insert(PointAVL<T> node, T data)
        {
            if (node == null)
            {
                node = new PointAVL<T> { Data = data };
            }
            else if (data.CompareTo(node.Data) < 0)
            {
                node.Left = Insert(node.Left, data);
            }
            else
            {
                node.Right = Insert(node.Right, data);
            }
            return Balance(node);
        }

        // Функция поиска наименьшего элемента
        T FindSmallestValue(PointAVL<T> point)
        {
            while (point.Left != null)
            {
                point = point.Left;
            }
            return point.Data;
        }



        // Функция удаления элемента

        PointAVL<T> Delete(PointAVL<T> node, T data)
        {
            if (node == null)
                throw new Exception("Элемент не найден");

            int compareResult = data.CompareTo(node.Data);
            if (compareResult < 0)
            {
                node.Left = Delete(node.Left, data);
            }
            else if (compareResult > 0)
            {
                node.Right = Delete(node.Right, data);
            }
            else
            {
                // У узла два потомка
                if (node.Left != null && node.Right != null)
                {
                    T smallestValueInRightSubtree = FindSmallestValue(node.Right);
                    node.Data = smallestValueInRightSubtree;
                    node.Right = Delete(node.Right, smallestValueInRightSubtree);
                }
                else
                {
                    // Один или ноль потомков
                    node = (node.Left != null) ? node.Left : node.Right;
                }
            }

            if (node != null)
                node = Balance(node);

            return node;
        }
        PointAVL<T> FindItem(PointAVL<T> point, T item)
        {
            if (point == null)
                return null;

            if (point.Data.Equals(item))
            {
                return point;
            }
            else
            {
                if (point.Data.CompareTo(item) < 0)
                    return FindItem(point.Left, item);
                else
                    return FindItem(point.Right, item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this).InOrder(this.root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            Insert(item);
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            return FindItem(root, item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (T item in this)
            {
                if (array.Length <= arrayIndex)
                {
                    T[] temp = new T[array.Length * 2];
                    for (int i = 0; i < array.Length; i++)
                    {
                        temp[i] = array[i];
                    }
                    array = temp;
                }
                array[arrayIndex] = (T)item.Clone();
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            root = Delete(root, item);
            return FindItem(root, item) == null;
        }

    }

}















