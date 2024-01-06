using Lab1_3;

namespace Lab2_3;

[TestFixture]
public class BinaryTreeTests
{
    [Test]
    public void GetEnumerator_ReturnsCorrectOrder()
    {
        // Arrange
        var binaryTree = new BinaryTree<int>();
        binaryTree.AddNode(5);
        binaryTree.AddNode(3);
        binaryTree.AddNode(7);
        binaryTree.AddNode(2);
        binaryTree.AddNode(4);
        binaryTree.AddNode(6);
        binaryTree.AddNode(8);

        // Act
        var result = new List<int>(binaryTree);

        // Assert
        CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 6, 7, 8 }, result);
    }

    [Test]
    public void GetEnumerator_ReturnsEmptyListForEmptyTree()
    {
        // Arrange
        var binaryTree = new BinaryTree<int>();

        // Act
        var result = new List<int>(binaryTree);

        // Assert
        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void GetEnumerator_ReturnsSingleNodeTree()
    {
        // Arrange
        var binaryTree = new BinaryTree<int>();
        binaryTree.AddNode(5);

        // Act
        var result = new List<int>(binaryTree);

        // Assert
        CollectionAssert.AreEqual(new[] { 5 }, result);
    }

    [Test]
    public void GetEnumerator_CorrectlyHandlesDuplicates()
    {
        // Arrange
        var binaryTree = new BinaryTree<int>();
        binaryTree.AddNode(5);
        binaryTree.AddNode(5);
        binaryTree.AddNode(3);

        // Act
        var result = new List<int>(binaryTree);

        // Assert
        CollectionAssert.AreEqual(new[] { 3, 5, 5 }, result);
    }
}
