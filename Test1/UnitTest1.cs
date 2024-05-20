using PlantLib;
using Task1;
using Task2;
using Task3;


namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructorLength()
        {
            MyList<Plant> myList = new MyList<Plant>(10);

            Assert.IsTrue(myList.Count == 10);
        }

        [TestMethod]
        public void TestRemoveItems()
        {
            MyList<Tree> myList = new MyList<Tree>();

            Tree expected = new Tree();
            Tree expected2 = new Tree();
            Tree expected3 = new Tree();

            myList.AddToEnd(expected);
            myList.AddToBegin(expected2);
            myList.AddToBegin(expected3);
            myList.RemoveOdd();

            Assert.AreEqual(myList.Count, 2);
        }

        //Добавление первого элемента
        [TestMethod]
        public void TestAddFirstItem()
        {
            MyList<Tree> myList = new MyList<Tree>();

            Tree expected = new Tree();
            myList.AddByPos(expected, 1);

            Assert.AreEqual(myList.Count, 2);
        }

        //Добавление последнего элемента
        [TestMethod]
        public void TestAddLastItem()
        {
            MyList<Tree> myList = new MyList<Tree>();

            Tree expected = new Tree();
            myList.AddToEnd(expected);
            myList.AddByPos(expected, 2);

            Assert.AreEqual(myList.Count, 3);
        }

        //Добавление  элемента в середину
        [TestMethod]
        public void TestAddMidleItem()
        {
            MyList<Tree> myList = new MyList<Tree>();

            Tree expected = new Tree();
            myList.AddToEnd(expected);
            myList.AddToEnd(expected);
            myList.AddToEnd(expected);
            myList.AddToEnd(expected);


            myList.AddByPos(expected, 2);

            Assert.AreEqual(myList.Count, 6);
        }

        [TestMethod]
        public void TestClear()
        {
            MyList<Plant> myList = new MyList<Plant>(10);

            myList.Clear();

            Assert.IsTrue(myList.Count == 1);
        }

        [TestMethod]
        public void TestClone()
        {
            MyList<Plant> myList = new MyList<Plant>(10);
            MyList<Plant> clone = myList.DeepCopy();
            myList.Clear();

            Assert.AreNotEqual(myList, clone);
        }
        //Тестирование HashTable

        [TestMethod]
        public void TestHashTableConstructor()
        {
            HashTable<Plant, Plant> myHashTable = new HashTable<Plant, Plant>();
            Assert.IsTrue(myHashTable.Count == 0 && myHashTable.Capacity == 10);

        }

        //добавление в таблицу
        [TestMethod]
        public void TestHashTableAddItem()
        {
            HashTable<Plant, Plant> myHashTable = new HashTable<Plant, Plant>();
            Plant expect = new Plant();
            expect.RandomInit();
            myHashTable.AddItem(expect, expect);
            Assert.IsTrue(myHashTable.Contains(expect));

        }

        //Добавление, когда кончилось место
        [TestMethod]
        public void TestHashTableAddMoreItem()
        {
            HashTable<Plant, Plant> myHashTable = new HashTable<Plant, Plant>(1);
            Plant expect = new Plant();
            expect.RandomInit();
            myHashTable.AddItem(expect, expect);
            expect.RandomInit();
            myHashTable.AddItem(expect, expect);
            Assert.IsTrue(myHashTable.Count == 2);

        }


        [TestMethod]
        public void TestHashTableRemoving()
        {
            HashTable<Plant, Plant> myHashTable = new HashTable<Plant, Plant>(1);
            Plant expect = new Plant();
            expect.RandomInit();
            myHashTable.AddItem(expect, expect);
            myHashTable.RemoveData(expect);
            Assert.IsTrue(!myHashTable.Contains(expect));

        }

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
        public void TestDeleteTree()
        {
            AVLTree<Plant> myTree = new();
            Plant plant = new Plant("Абелия", "красный", 100);
            Plant plant1 = new Plant("Роза", "красный", 110);

            myTree.Insert(plant1);
            myTree.Insert(plant);

            myTree.DeleteTree();
            Assert.IsNull(myTree.root);
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
    }
}