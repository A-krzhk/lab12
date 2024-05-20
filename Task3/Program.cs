using PlantLib;

namespace Task3
{
    internal class Program
    {
        //3 задание
        static void Main(string[] args)
        {
            AVLTree<Plant> tree = new AVLTree<Plant>();

            for (int i = 1; i <= 8; i++)
            {
                Plant data = new Plant();
                data.RandomInit();
                tree.Insert(data);
            }

            tree.ShowTree();
            Console.WriteLine("Наименьшее значение:");
            tree.FindSmallest();
        }
    }
}
