using PlantLib;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree<Plant> tree = new AVLTree<Plant>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Создать коллекцию определенной длины");
                Console.WriteLine("2. Добавить элемент");
                Console.WriteLine("3. Удалить элемент");
                Console.WriteLine("4. Найти элемент");
                Console.WriteLine("5. Показать дерево по уровням");
                Console.WriteLine("6. Показать все элементы (foreach)");
                Console.WriteLine("7. Выйти");
                Console.Write("Выберите опцию: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите длину коллекции: ");
                        int length;
                        if (int.TryParse(Console.ReadLine(), out length) && length > 0)
                        {
                            tree = new AVLTree<Plant>(length);
                            Console.WriteLine($"Коллекция из {length} элементов создана.");
                        }
                        else
                        {
                            Console.WriteLine("Неверная длина. Попробуйте снова.");
                        }
                        break;
                    case "2":
                        
                        Plant plantToAdd = new Plant ();
                        plantToAdd.Init();
                        tree.Add(plantToAdd);
                        Console.WriteLine("Элемент добавлен.");
                        break;

                    case "3":
                        Plant plantToRemove = new Plant();
                        plantToRemove.Init();
                        if (tree.Remove(plantToRemove))
                        {
                            Console.WriteLine("Элемент удален.");
                        }
                        else
                        {
                            Console.WriteLine("Элемент не найден.");
                        }
                        break;

                    case "4":

                        Plant plantToFind = new Plant();
                        plantToFind.Init();
                        if (tree.Contains(plantToFind))
                        {
                            Console.WriteLine("Элемент найден.");
                        }
                        else
                        {
                            Console.WriteLine("Элемент не найден.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Дерево:");
                        tree.ShowTree();
                        break;

                    case "6":
                        Console.WriteLine("Все элементы:");
                        foreach (var item in tree)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "7":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    
}
}
