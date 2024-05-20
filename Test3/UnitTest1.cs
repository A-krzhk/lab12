using PlantLib;
using Task3;
namespace Test3
{
    [TestClass]
    public class UnitTest1
    {
        //Тестирование АВЛ дерева
        [TestMethod]
        public void TestFindSmallest()
        {
            AVLTree<Plant> myTree = new AVLTree<Plant>();
            Plant plant = new Plant("Абелия", "красный", 100);
            Plant plant1 = new Plant("Роза", "красный", 110);

            myTree.Insert(plant1);
            myTree.Insert(plant);

            Plant expect = myTree.FindSmallest();
            Assert.AreEqual(expect, plant);
        }

        [TestMethod]
        public void TestInsertAndBalance()
        {
            // Arrange
            AVLTree<Plant> myTree = new();
            Plant plant1 = new Plant("Абелия", "красный", 100);
            Plant plant2 = new Plant("Роза", "красный", 110);
            Plant plant3 = new Plant("Магнолия", "красный", 10);


            // Act
            myTree.Insert(plant1);
            myTree.Insert(plant2);
            myTree.Insert(plant3);

            // Assert
            Assert.IsNotNull(myTree.root);
            Assert.AreEqual(plant3, myTree.root.Data);
            Assert.AreEqual(plant1, myTree.root.Left.Data);
            Assert.AreEqual(plant2, myTree.root.Right.Data);
        }

        //Удаление узла с двумя потомками
        [TestMethod]
        public void Delete_ElementExists_ElementDeleted()
        {
            AVLTree<Plant> avlTree = new();

            Plant data1 = new Plant();
            Tree data2 = new Tree();
            Rose data3 = new Rose();

            avlTree.Insert(data1);
            avlTree.Insert(data2);
            avlTree.Insert(data3);

            avlTree.Delete(data2);


        }

        //Удаление узла с потомком
        [TestMethod]
        public void DeleteElementRight()
        {
            AVLTree<Plant> avlTree = new();

            Plant data1 = new Plant { Name = "Кактус", Color = "Синий" };
            Plant data2 = new Plant { Name = "Мак", Color = "Зеленый" };

            avlTree.Insert(data1);
            avlTree.Insert(data2);

            avlTree.Delete(data2);
            Assert.AreEqual(avlTree.root.Data, data1);


        }

        //Удаление узла с потомком
        [TestMethod]
        public void DeleteElementLeft()
        {
            AVLTree<Plant> avlTree = new();

            Plant data1 = new Plant { Name = "Кактус", Color = "Синий" };
            Plant data2 = new Plant { Name = "Мак", Color = "Зеленый" };

            avlTree.Insert(data2);
            avlTree.Insert(data1);

            avlTree.Delete(data1);
            Assert.AreEqual(avlTree.root.Data, data2);


        }
        //Удаление несущесьвующего элемента
        [TestMethod]
        public void DeleteElementNull()
        {
            AVLTree<Plant> avlTree = new();

            Plant data1 = new Plant { Name = "Кактус", Color = "Синий" };
            Plant data2 = new Plant { Name = "Мак", Color = "Зеленый" };

            avlTree.Insert(data1);
            avlTree.Insert(data2);

            try
            {
                avlTree.Delete(new Tree());
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Элемент не найден", ex.Message);
            }

        }


        [TestMethod]
        public void TestDeleteTree()
        {
            AVLTree<Plant> avlTree = new();

            Plant data1 = new Plant { Name = "Голубика", Color = "Желтый" };
            Plant data2 = new Plant { Name = "Беладонна", Color = "Белый" };
            Plant data3 = new Plant { Name = "Инжир", Color = "Черный" };
            Plant data4 = new Plant { Name = "Кактус", Color = "зеленый" };
            Plant data5 = new Plant { Name = "Роза", Color = "Красный" };

            avlTree.Insert(data1);
            avlTree.Insert(data2);
            avlTree.Insert(data3);
            avlTree.Insert(data4);
            avlTree.Insert(data5);

            avlTree.DeleteTree();
            Assert.AreEqual(avlTree.root, null);

        }
    }
}