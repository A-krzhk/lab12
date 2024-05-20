using PlantLib;
namespace Task2
{
    internal class Program
    {
        //2 задание
        public static void ShowMenu()
        {
            Console.WriteLine("\n******************************************************");
            Console.WriteLine("Выберите пункт меню: ");
            Console.WriteLine("1. Добавить элемент в хэш-таблицу");
            Console.WriteLine("2. Выполнить поиск элемента по ключу");
            Console.WriteLine("3. Удалить элемент по ключу");
            Console.WriteLine("4. Напечатать хэш-таблицу");
            Console.WriteLine("5. Выход");
            Console.WriteLine("******************************************************\n");

        }
        public static void ShowMenuPlant()
        {
            Console.WriteLine("\n******************************************************");
            Console.WriteLine("Выберите пункт меню: ");
            Console.WriteLine("1. Добавить дерево");
            Console.WriteLine("2. Добавить розу");
            Console.WriteLine("3. Добавить растение (базовый)");
            Console.WriteLine("******************************************************\n");
        }
        public static int InputNum()
        {
            bool isConvert;
            int number;
            do
            {
                isConvert = int.TryParse(Console.ReadLine(), out number);
                if (!isConvert)
                    Console.WriteLine("Неправильный ввод!");
            } while (!isConvert);
            return number;
        }

        static void Main(string[] args)
        {
            HashTable<Plant, Plant> myHashTable = new HashTable<Plant, Plant>();
            while (true)
            {
                ShowMenu();
                int choice = InputNum();

                switch (choice)
                {
                    case 1:
                        {
                            ShowMenuPlant();
                            int choiceType = InputNum();
                            switch (choiceType)
                            {
                                case 1:
                                    {
                                        Tree t1 = new Tree();
                                        Console.WriteLine("Элемент для добавления:");
                                        t1.Init();
                                        Plant key = new Plant();

                                        Console.WriteLine("Ключ для элемента:");
                                        key.Init();
                                        myHashTable.AddItem(key, t1);
                                        break;
                                    }
                                case 2:
                                    {
                                        Rose r1 = new Rose();
                                        r1.RandomInit();
                                        Plant key = new Plant();
                                        key.RandomInit();
                                        myHashTable.AddItem(key, r1);
                                        break;
                                    }
                                case 3:
                                    {
                                        Plant p1 = new Plant();
                                        p1.RandomInit();
                                        Plant key = new Plant();
                                        key.RandomInit();
                                        myHashTable.AddItem(key, p1);
                                        break;
                                    }
                                default:
                                    Console.WriteLine("Введено некорректное значение. Повторите ввод.");
                                    break;
                            }

                            Console.WriteLine("Элемент добавлен");
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Введите ключ для поиска элемента: ");

                            Plant key = new Plant();
                            key.Init();
                            if (myHashTable.FindItem(key) != -1)
                                Console.WriteLine($"Ваш элемент находится на {myHashTable.FindItem(key) + 1}-ой позиции");
                            else
                                Console.WriteLine("Элемент по данному ключу не найден");
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Введите ключ для удаления элемента: ");

                            Plant key = new Plant();
                            key.Init();
                            if (myHashTable.RemoveData(key))
                                Console.WriteLine("Элемент по данному ключу удалён");
                            else
                                Console.WriteLine("Элемент по данному ключу не найден");
                            break;
                        }

                    case 4:
                        Console.WriteLine("Текущая хэш-таблица:");
                        myHashTable.Print();
                        break;

                    case 5:
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
