using PlantLib;

namespace Task3
{
    internal class Program
    {
        //3 задание
        static void Main(string[] args)
        {
            var avlTree = new AVLTree<Plant>(); // Замените MyData на ваш тип данных, реализующий IInit и IComparable

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить элемент");
                Console.WriteLine("2 - Удалить элемент");
                Console.WriteLine("3 - Показать дерево");
                Console.WriteLine("4 - Найти наименьший элемент");
                Console.WriteLine("5 - Очистить дерево");
                Console.WriteLine("0 - Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Plant plant = new Plant();
                        plant.RandomInit();
                        avlTree.Insert(plant);
                        Console.WriteLine("Элемент добавлен.");
                        break;

                    case "2":
                        Plant deleteData = new Plant();
                        deleteData.Init();
                        try
                        {
                            avlTree.Delete(deleteData);
                            Console.WriteLine("Элемент удален.");

                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        break;

                    case "3":
                        Console.WriteLine("AVL дерево:");
                        avlTree.ShowTree();
                        break;

                    case "4":
                        try
                        {
                            var smallest = avlTree.FindSmallest();
                            Console.WriteLine($"Наименьший элемент: {smallest}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "5":
                        avlTree.DeleteTree();
                        Console.WriteLine("Дерево очищено.");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }

    
}
