using PlantLib;
using Task3;
namespace Test3
{
    [TestClass]
    public class UnitTest1
    {
        //������������ ��� ������
        [TestMethod]
        public void TestFindSmallest()
        {
            AVLTree<Plant> myTree = new AVLTree<Plant>();
            Plant plant = new Plant("������", "�������", 100);
            Plant plant1 = new Plant("����", "�������", 110);

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
            Plant plant1 = new Plant("������", "�������", 100);
            Plant plant2 = new Plant("����", "�������", 110);
            Plant plant3 = new Plant("��������", "�������", 10);


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

        //�������� ���� � ����� ���������
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

        //�������� ���� � ��������
        [TestMethod]
        public void DeleteElementRight()
        {
            AVLTree<Plant> avlTree = new();

            Plant data1 = new Plant { Name = "������", Color = "�����" };
            Plant data2 = new Plant { Name = "���", Color = "�������" };

            avlTree.Insert(data1);
            avlTree.Insert(data2);

            avlTree.Delete(data2);
            Assert.AreEqual(avlTree.root.Data, data1);


        }

        //�������� ���� � ��������
        [TestMethod]
        public void DeleteElementLeft()
        {
            AVLTree<Plant> avlTree = new();

            Plant data1 = new Plant { Name = "������", Color = "�����" };
            Plant data2 = new Plant { Name = "���", Color = "�������" };

            avlTree.Insert(data2);
            avlTree.Insert(data1);

            avlTree.Delete(data1);
            Assert.AreEqual(avlTree.root.Data, data2);


        }
        //�������� ��������������� ��������
        [TestMethod]
        public void DeleteElementNull()
        {
            AVLTree<Plant> avlTree = new();

            Plant data1 = new Plant { Name = "������", Color = "�����" };
            Plant data2 = new Plant { Name = "���", Color = "�������" };

            avlTree.Insert(data1);
            avlTree.Insert(data2);

            try
            {
                avlTree.Delete(new Tree());
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������� �� ������", ex.Message);
            }

        }


        [TestMethod]
        public void TestDeleteTree()
        {
            AVLTree<Plant> avlTree = new();

            Plant data1 = new Plant { Name = "��������", Color = "������" };
            Plant data2 = new Plant { Name = "���������", Color = "�����" };
            Plant data3 = new Plant { Name = "�����", Color = "������" };
            Plant data4 = new Plant { Name = "������", Color = "�������" };
            Plant data5 = new Plant { Name = "����", Color = "�������" };

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