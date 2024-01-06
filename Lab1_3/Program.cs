namespace Lab1_3;

internal class Program
{
    private static void Main()
    {
        var binaryTree = new BinaryTree<int>();

        // Підписка на події
        binaryTree.CollectionCleared += HandleCollectionCleared;
        binaryTree.ItemAdded += HandleItemAdded;
        binaryTree.ItemRemoved += HandleItemRemoved;

        // Додавання вузлів та інші операції
        Console.WriteLine("Adding nodes to the binary tree:");
        binaryTree.AddNode(5);
        binaryTree.AddNode(3);
        binaryTree.AddNode(7);
        binaryTree.AddNode(2);
        binaryTree.AddNode(4);
        binaryTree.AddNode(6);
        binaryTree.AddNode(8);

        // Вивід вузлів в порядку ін-ордер обходу
        Console.WriteLine("In-order traversal of the binary tree:");
        binaryTree.InOrderTraversal(node => Console.Write($"{node} "));
        Console.WriteLine();

        // Пошук елемента
        const int searchElement = 4;
        Console.WriteLine($"Searching for {searchElement}: {binaryTree.Contains(searchElement)}");

        // Видалення вузла
        const int removeElement = 7;
        Console.WriteLine($"Removing {removeElement} from the binary tree:");
        binaryTree.RemoveNode(removeElement);

        // Вивід вузлів після видалення
        Console.WriteLine("In-order traversal after removing a node:");
        binaryTree.InOrderTraversal(node => Console.Write($"{node} "));
        Console.WriteLine();

        // Очищення колекції
        Console.WriteLine("Clearing the binary tree:");
        binaryTree.Clear();

        // Вивід порожньої колекції
        Console.WriteLine("In-order traversal after clearing the binary tree:");
        binaryTree.InOrderTraversal(node => Console.Write($"{node} "));
    }

    private static void HandleCollectionCleared(object? sender, EventArgs e)
    {
        Console.WriteLine("Collection Cleared");
    }

    private static void HandleItemAdded(object? sender, ItemAddedEventArgs<int> e)
    {
        Console.WriteLine($"Item Added: {e.Item}");
    }

    private static void HandleItemRemoved(object? sender, ItemRemovedEventArgs<int> e)
    {
        Console.WriteLine($"Item Removed: {e.Item}");
    }
}
