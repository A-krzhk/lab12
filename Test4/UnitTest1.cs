using PlantLib;
using System.Xml.Linq;
using Task4;
namespace Test4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructorLength()
        {
            AVLTree<Plant> myTree = new(20);

            Assert.IsTrue(myTree.Count == 20);
        }

        [TestMethod]
        public void TestRemove()
        {
            AVLTree<Plant> myTree = new(10);

            Plant plant = (Plant)myTree.root.Data.Clone();
            plant.id.Number = plant.id.Number;

            myTree.Remove(myTree.root.Data);

            Assert.IsTrue(!myTree.Contains(plant));
        }

        [TestMethod]
        public void TestClear()
        {
            AVLTree<Plant> myTree = new(10);

            myTree.Clear();

            Assert.IsTrue(myTree.root == null && myTree.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CopyTo_NegativeArrayIndex_ThrowsArgumentOutOfRangeException()
        {
            AVLTree<Plant> avlTree = new(10);

            Plant[] array = new Plant[avlTree.Count];
            avlTree.CopyTo(array, -1);
        }

        [TestMethod]
        public void TestCloneCopy()
        {
            AVLTree<Plant> myTree = new(10);
            AVLTree<Plant> clone = new(myTree);
            Plant[] copy = new Plant[10];

            clone.root = new PointAVL<Plant>();
            myTree.CopyTo(copy, 5);
            bool isContains = true;
            int i = 5;
            while (isContains && i < copy.Length)
            {
                isContains = myTree.Contains(copy[i]);
                i++;
            }

            Assert.IsTrue(!myTree.Contains(clone.root.Data));
        }
    }
}