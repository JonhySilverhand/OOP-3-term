using System;
using System.Collections.Generic;
using System.Text;

namespace Lab07
{
    /*№1 Создать заданный в варианте класс. Определить в классе необходимые 
         методы, конструкторы, индексаторы и заданные перегруженные 
         операции. */
    public class Stack<T> : Interface<T> //where T : class
    {
        public readonly List<T> list;
        public int _top;
        public Stack()
        {
            this._top = 0;
            this.list = new List<T>();
        }
        public int Top
        {
            get { return this._top; }
        }

        public int Count
        {
            get { return this._top; }
        }
        public bool IsEmpty()
        {
            if (list.Count == 0)
                return true;
            else
                return false;
        }
        public void Push(T elem)
        {
            this.list.Insert(_top, elem);
        }
        public void Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            this.list.RemoveAt(_top);
        }
        public T Peek()
        {
            return list[_top];
        }
        public void CheckList()
        {
            if (IsEmpty())
                Console.WriteLine("Stack is empty");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("->" + list[i]);
            }
            Console.WriteLine($"Всего элементов в стеке: {list.Count}");
        }

        //Дополнительно перегрузить следующие 
        //операции: + - добавить элемент в стек; -- - извлечь элемент из
        //стека; true - проверка, пустой ли стек; > - копирование одного
        //стека в другой с сортировкой в возрастающем порядке.
        public static Stack<T> operator +(Stack<T> a, T elem)
        {
            a.Push(elem);
            return a;
        }
        public static Stack<T> operator --(Stack<T> a)
        {
            a.Pop();
            return a;
        }
        public static bool operator true(Stack<T> a)
        {
            if(a.Count == 0)
                return false;
            return true;
        }
        public static bool operator false(Stack<T> a)
        {
            if(a.Count > 0)
                return true;
            return false;
        }
        public static Stack<T> operator >(Stack<T> a, Stack<T> b)
        {
            a.list.Sort();
            b = a;
            return b;
        }
        public static Stack<T> operator <(Stack<T> a, Stack<T> b)
        {
            a.list.Sort();
            b = a;
            return b;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
