using System.Collections;
namespace CustomSinglyLinkedList;

internal class CustomList<T> : IList<T>
{
    private Node<T>? _head;
    public int Count { get; private set; }
    public bool IsReadOnly => true;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            return current!.Data!;
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            current!.Data = value;
        }
    }

    public bool Remove(T item)
    {
        if (_head is null) return false;

        if (Equals(item, _head!.Data))
        {
            _head = _head!.Next;
            Count--;
            return true;
        }

        var current = _head;
        for (int i = 0; i < Count - 1; i++)
        {
            if (Equals(item, current!.Next!.Data))
            {
                current.Next = current.Next!.Next;
                Count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Equals(this[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        Node<T> newNode = new Node<T> { Data = item };

        if (index is 0)
        {
            newNode.Next = _head;
            _head = newNode;
        }
        else
        {
            var current = _head!;
            for (int i = 0; i < index - 1; i++)
            {
                current = current!.Next;
            }
            newNode.Next = current!.Next;
            current.Next = newNode;
        }
        Count++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        if (index is 0) _head = _head!.Next;
        else
        {
            var current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current!.Next;
            }
            current!.Next = current.Next!.Next;
        }
        Count--;
    }

    public void Add(T item)
    {
        var newNode = new Node<T> { Data = item };

        if (_head is null) _head = newNode;
        else
        {
            var current = _head;
            while (current!.Next is not null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        Count++;
    }

    public void Clear()
    {
        if (_head is null) return;

        _head = default;
        Count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Equals(this[i], item)) return true;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }
        if (Count > array.Length - arrayIndex)
        {
            throw new ArgumentException();
        }

        var current = _head;
        for (int i = 0; i < arrayIndex + Count; i++)
        {
            array[i] = current!.Data!;
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new CustomListEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}