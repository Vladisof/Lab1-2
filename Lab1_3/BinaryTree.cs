using System.Collections;

namespace Lab1_3;

public sealed class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
{
    private BinaryTreeNode<T>? Root { get; set; }

    public void AddNode(T data)
    {
        Root = AddNodeRecursive(Root, data);
        OnItemAdded(data);
    }

    private static BinaryTreeNode<T> AddNodeRecursive(BinaryTreeNode<T>? current, T data)
    {
        if (current == null)
            return new BinaryTreeNode<T>(data);

        switch (data.CompareTo(current.Data))
        {
            case < 0:
                current.Left = AddNodeRecursive(current.Left, data);
                break;
            case >= 0:
                current.Right = AddNodeRecursive(current.Right, data);
                break;
        }

        return current;
    }

    public void InOrderTraversal(Action<T> action)
    {
        InOrderTraversalRecursive(Root, action);
    }

    private static void InOrderTraversalRecursive(BinaryTreeNode<T>? node, Action<T> action)
    {
        if (node == null)
            return;

        InOrderTraversalRecursive(node.Left, action);
        action(node.Data);
        InOrderTraversalRecursive(node.Right, action);
    }

    public bool Contains(T data)
    {
        return ContainsRecursive(Root, data);
    }

    private static bool ContainsRecursive(BinaryTreeNode<T>? node, T data)
    {
        if (node == null)
            return false;

        if (data.CompareTo(node.Data) == 0)
            return true;

        return data.CompareTo(node.Data) < 0
            ? ContainsRecursive(node.Left, data)
            : ContainsRecursive(node.Right, data);
    }

    public void RemoveNode(T data)
    {
        Root = RemoveNodeRecursive(Root, data);
        OnItemRemoved(data);
    }

    private static BinaryTreeNode<T>? RemoveNodeRecursive(BinaryTreeNode<T>? current, T data)
    {
        if (current == null)
            return null;

        switch (data.CompareTo(current.Data))
        {
            case 0 when current.Left == null:
                return current.Right;
            case 0 when current.Right == null:
                return current.Left;
            case 0:
                current.Data = FindMinValue(current.Right);
                current.Right = RemoveNodeRecursive(current.Right, current.Data);
                break;
            case < 0:
                current.Left = RemoveNodeRecursive(current.Left, data);
                break;
            default:
                current.Right = RemoveNodeRecursive(current.Right, data);
                break;
        }

        return current;
    }

    private static T FindMinValue(BinaryTreeNode<T> node)
    {
        return node.Left == null ? node.Data : FindMinValue(node.Left);
    }

    public void Clear()
    {
        Root = null;
        OnCollectionCleared();
    }

    public event EventHandler CollectionCleared = null!;
    public event EventHandler<ItemAddedEventArgs<T>> ItemAdded = null!;
    public event EventHandler<ItemRemovedEventArgs<T>> ItemRemoved = null!;

    private void OnCollectionCleared()
    {
        CollectionCleared?.Invoke(this, EventArgs.Empty);
    }

    private void OnItemAdded(T item)
    {
        ItemAdded?.Invoke(this, new ItemAddedEventArgs<T>(item));
    }

    private void OnItemRemoved(T item)
    {
        ItemRemoved?.Invoke(this, new ItemRemovedEventArgs<T>(item));
    }

    public IEnumerator<T> GetEnumerator()
    {
        return InOrderTraversal().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<T> InOrderTraversal()
    {
        if (Root == null)
            yield break;

        var stack = new Stack<BinaryTreeNode<T>>();
        var current = Root;

        while (stack.Count > 0 || current != null)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            yield return current.Data;

            current = current.Right;
        }
    }
}
