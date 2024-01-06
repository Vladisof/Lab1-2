namespace Lab1_3;

public class BinaryTreeNode<T>
{
    public T Data { get; set; }
    public BinaryTreeNode<T>? Left { get; set; }
    public BinaryTreeNode<T>? Right { get; set; }

    public BinaryTreeNode(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}
