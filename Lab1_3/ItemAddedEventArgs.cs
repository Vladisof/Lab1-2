namespace Lab1_3;

public class ItemAddedEventArgs<T> : EventArgs
{
    public T Item { get; }

    public ItemAddedEventArgs(T item)
    {
        Item = item;
    }
}