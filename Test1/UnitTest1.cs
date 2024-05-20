using PlantLib;
using System.Xml.Linq;
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
        public void TestZeroDeepCopy()
        {
            MyList<Plant> myList = new MyList<Plant>();
            MyList<Plant> clone = myList.DeepCopy();
            Tree tree = new Tree();
            myList.AddToBegin(tree);

            Assert.AreNotEqual(myList, clone);
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
        

        



    }
}