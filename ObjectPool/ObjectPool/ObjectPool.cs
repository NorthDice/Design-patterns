using System;
using System.Collections.Generic;

public class ObjectPool<T>
{
    private readonly Func<T> _objectGenerator;
    private readonly Queue<T> _objects;

    public ObjectPool(Func<T> objectGenerator)
    {
        _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
        _objects = new Queue<T>();
    }

    public T GetObject()
    {
        lock (_objects)
        {
            if (_objects.Count > 0)
            {
                return _objects.Dequeue();
            }
            else
            {
                return _objectGenerator();
            }
        }
    }

    public void ReturnObject(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        lock (_objects)
        {
            _objects.Enqueue(item);
        }
    }
}
