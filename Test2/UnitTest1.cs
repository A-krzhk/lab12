using PlantLib;
using Task2;

namespace Test2
{
    [TestClass]
    public class UnitTest1
    {
        //Тестирование HashTable

        [TestMethod]
        public void TestHashTableConstructor()
        {
            HashTable<Plant, Plant> myHashTable = new HashTable<Plant, Plant>();
            Assert.IsTrue(myHashTable.Count == 0 && myHashTable.Capacity == 10);

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

        //Добавление, когда кончилось место
        [TestMethod]
        public void TestHashTableAddMoreItemType2()
        {
            HashTable<Plant, Plant> myHashTable = new HashTable<Plant, Plant>(3);
            Plant expect = new Plant();
            expect.RandomInit();
            myHashTable.AddItem(expect, expect);
            Tree tree = new Tree();
            myHashTable.AddItem(tree, tree);
            tree.RandomInit();
            myHashTable.AddItem(expect, expect);
            Assert.IsTrue(myHashTable.Count == 3);

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
    }
}