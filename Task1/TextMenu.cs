using PlantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class TextMenu<T> where T : IInit, ICloneable, new()
    {
        public static void ShowMenu() //передать массив строк
        {
            Console.WriteLine("\n******************************************************");
            Console.WriteLine("Выберите пункт меню: ");
            Console.WriteLine("1. Добавить элемент в начало");
            Console.WriteLine("2. Добавить элемент в конец");
            Console.WriteLine("3. Добавить элемент на указанную позицию");
            Console.WriteLine("4. Удалить все нечетные элементы");
            Console.WriteLine("5. Напечатать список");
            Console.WriteLine("6. Выход");
            Console.WriteLine("******************************************************\n");

        }
        public static int InputNum()
        {
            int positionToAdd;
            try
            {
                positionToAdd = Convert.ToInt32(Console.ReadLine());
                return positionToAdd;
            }
            catch
            {
                throw new Exception("Введено не число");
            }
        }

        public static int ChoiceForInput()
        {
            int addChoice;
            do
            {
                Console.WriteLine("Выберите пункт меню: ");
                Console.WriteLine("1. Добавить элемент, с ручным вводом");
                Console.WriteLine("2. Добавить случайный элемент");
                Int32.TryParse(Console.ReadLine(), out addChoice);
            } while (addChoice != 1 && addChoice != 2);

            return addChoice;
        }

        public static void RunMenu()
        {
            MyList<T> myList = new MyList<T>(); // список, с которым ведется работа
            while (true)
            {
                ShowMenu();
                int choice = Convert.ToInt32(Console.ReadLine()); // зацикленность меню

                T newItem = new T(); // этот элемент добавляется

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Добавление элемента в начало списка: ");

                        //Здесь делается заполнение вручную или рандомом в зависимости от выбора пользователя
                        switch (ChoiceForInput())
                        {
                            case 1:
                                newItem = myList.MakeInitItem();
                                myList.AddToBegin(newItem);
                                break;
                            case 2:
                                newItem = myList.MakeRandomItem();
                                myList.AddToBegin(newItem);
                                break;
                        }
                        Console.WriteLine("Элемент добавлен");
                        break;

                    case 2:
                        Console.WriteLine("Добавление элемента в конец списка: ");

                        //Здесь делается заполнение вручную или рандомом в зависимости от выбора пользователя
                        switch (ChoiceForInput())
                        {
                            case 1:
                                newItem = myList.MakeInitItem();
                                myList.AddToEnd(newItem);
                                break;
                            case 2:
                                newItem = myList.MakeRandomItem();
                                myList.AddToEnd(newItem);
                                break;
                        }
                        Console.WriteLine("Элемент добавлен");
                        break;
                    case 3:
                        Console.WriteLine("Добавление элемента на указанную позицию: ");

                        //Здесь делается заполнение вручную или рандомом в зависимости от выбора пользователя
                        switch (ChoiceForInput())
                        {
                            case 1:
                                newItem = myList.MakeInitItem();
                                break;

                            case 2:
                                newItem = myList.MakeRandomItem();
                                break;
                        }
                        //Ввод позиции для добавления + проверка введенного значения через catch
                        try
                        {
                            Console.WriteLine("Введите позицию, на которую хотите добавить элемент: ");
                            int positionToAdd = InputNum();

                            myList.AddByPos(newItem, positionToAdd);
                            Console.WriteLine("Элемент добавлен");

                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 4:
                        try
                        {
                            myList.RemoveOdd();
                            Console.WriteLine("Нечетные элементы удалены");
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }

                        break;
                    case 5:
                        Console.WriteLine("Текущий список:");
                        myList.PrintList();
                        break;
                    case 6:
                        Console.WriteLine("Программа остановлена...");
                        return;
                    default:
                        Console.WriteLine("Введено некорректное значение. Повторите ввод.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
