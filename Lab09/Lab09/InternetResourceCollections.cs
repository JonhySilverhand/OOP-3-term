using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Linq;
using System.Collections;

namespace Lab09
{
    public class InternetResourceCollections<T> : IList<T>
    {
        private T[] mas;
        private int _count;
        public bool IsReadOnly { get => false; }
        public InternetResourceCollections()
        {
            _count = 0;
            mas = Array.Empty<T>();
        }
        //IList Members

        public void Add(T item)
        {
            var tmp = new T[_count + 1];
            mas.CopyTo(tmp, 0);
            mas = tmp;
            mas[_count] = item;
            _count++;
        }

        public void Clear()
        {
            _count = 0;
            mas = Array.Empty<T>();
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(mas[i], item))
                    return true;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(mas[i], item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if ((_count + 1 <= mas.Length) && (index < Count) && (index >= 0))
            {
                _count++;
                for (int i = Count - 1; i > index; i--)
                {
                    mas[i] = mas[i - 1];
                }
                mas[index] = item;
            }
        }

        public bool IsFixedSize { get => true; }

        public bool Remove(T item)
        {
            int numIndex = Array.IndexOf(mas, item);
            if (numIndex == -1)
                return false;
            mas = mas.Where((val, idx) => idx != numIndex).ToArray();
            _count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                    mas[i] = mas[i + 1];
                _count--;
            }
        }

        public T this[int index] { get => mas[index]; set => mas[index] = value; }

        //ICollection Members

        public void CopyTo(T[] array, int index)
        {
            for (int i = 0; i < Count; i++)
                array.SetValue(mas[i], index++);
        }

        public int Count { get => _count; }

        //IEnumerable Members

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < mas.Length; i++)
                yield return mas[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PrintList()
        {
            Console.WriteLine($"List has a capacity of {mas.Length} and currently has {_count} elements.");
            Console.WriteLine("List contents:");
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"{mas[i]}");
            }
            Console.WriteLine();
        }
    }
    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        for (var i = 0; i < mas.Length; i++)
    //            yield return mas[i];
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }

    //    public void Add(T item)
    //    {
    //        if (item == null)
    //            throw new NullReferenceException();

    //        var tmp = new T[Count + 1];
    //        mas.CopyTo(tmp, 0);
    //        mas = tmp;
    //        mas[Count] = item;
    //        Count++;
    //    }
     
    //    public void Clear()
    //    {
    //        mas = Array.Empty<T>();
    //        Count = 0;
    //    }
       
    //    public bool Contains(T item)
    //    {
    //        for (var i = 0; i < Count; i++)
    //            if ((Equals(mas[i], item)))
    //                return true;

    //        return false;
    //    }
       
    //    public void CopyTo(T[] array, int arrayIndex)
    //    {
    //        if (array.Length - arrayIndex < Count)
    //            throw new ArgumentOutOfRangeException();
    //        for (var i = 0; i < Count; i++)
    //            array[arrayIndex + i] = mas[i];
    //    }
       
    //    public bool Remove(T item)
    //    {
    //        int numIndex = Array.IndexOf(mas, item);
    //        if (numIndex == -1)
    //            return false;
    //        mas = mas.Where((val, idx) => idx != numIndex).ToArray();
    //        Count--;
    //        return true;
    //    }

    //    public int IndexOf(T item)
    //    {
    //        for (int i = 0; i < Count; i++)
    //        {
    //            if (Equals(mas[i], item))
    //                return i;
    //        }
    //        return -1;
    //    }

    //    public void Insert(int index, T item)
    //    {
    //        if (index < 0 || index > Count)
    //            throw new ArgumentOutOfRangeException();

    //        Count++;
    //        var tmp = new T[Count];
    //        mas.CopyTo(tmp, 0);
    //        mas = tmp;
    //        for (int i = Count - 1; i > index; i--)
    //            mas[i] = mas[i - 1];

    //        mas[index] = item;
    //    }

    //    public void RemoveAt(int index)
    //    {
    //        if (index < 0 || index >= Count)
    //            throw new ArgumentOutOfRangeException();

    //        mas = mas.Where((val, idx) => idx != index).ToArray();
    //        Count--;
    //    }

    //    public T this[int index] { get => mas[index]; set => mas[index] = value; }

    //    public void ShowList()
    //    {
    //        Console.ForegroundColor = ConsoleColor.White;
    //        foreach(var x in mas)
    //        {
    //            Console.WriteLine($"{x.ToString()}");
    //        }
            
    //        Console.ForegroundColor = ConsoleColor.Blue;
    //    }
    //}
}
