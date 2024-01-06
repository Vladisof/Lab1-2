namespace Lab1_3;

public class ItemRemovedEventArgs<T> : EventArgs
{
    public T Item { get; }

    public ItemRemovedEventArgs(T item)
    {
        Item = item;
    }
}