using System.Collections;
namespace CustomSinglyLinkedList;

internal class CustomListEnumerator<T> : IEnumerator<T>
{
    private readonly CustomList<T> _list;
    private int _currentIndex = -1;

    public CustomListEnumerator(CustomList<T> list) => _list = list;

    public bool MoveNext()
    {
        if (_currentIndex >= _list.Count - 1) return false;
        _currentIndex++;

        return true;
    }

    public void Reset() => _currentIndex = -1;

    public T Current
    {
        get
        {
            if (_currentIndex is -1 || _currentIndex > _list.Count)
            {
                throw new ArgumentException();
            }
            return _list[_currentIndex];
        }
    }

    object? IEnumerator.Current => Current;

    public void Dispose() { } /* ??? */
}