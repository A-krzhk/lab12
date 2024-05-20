using PlantLib;
namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 задание
            MyList<Plant> list = new MyList<Plant>();

            // Запуск меню
            TextMenu<Plant>.RunMenu();
        }
    }
}
