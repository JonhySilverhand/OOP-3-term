using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03
{
    /*№1 Создать заданный в варианте класс. Определить в классе необходимые 
         методы, конструкторы, индексаторы и заданные перегруженные 
         операции. */
    public class Stack
    {
        //№2 Добавьте в свой класс вложенный объект Production, который содержит 
        //   Id, название организации. Проинициализируйте его

        public class Production
        {
            private readonly int organisationID;
            public string OrganisationName { get; set; }
            public Production()
            {
                organisationID = GetHashCode();
            }
            public Production(string name)
            {
                organisationID = GetHashCode();
                this.OrganisationName = name;
            }
        }

        // Добавьте в свой класс вложенный класс Developer (разработчик – фио, 
        // id, отдел). Проинициализируйте

        public class Developper
        {
            private readonly int DevID;
            public string Name { get; set; }
            public string Department { get; set; }
            public Developper()
            {
                DevID = GetHashCode();
            }
            public Developper(string name, string depart)
            {
                DevID = GetHashCode();
                this.Name = name;
                this.Department = depart;
            }
        }

        public readonly List<string> list;
        public int _top;
        public Stack()
        {
            this._top = 0;
            this.list = new List<string>();
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
        public void Push(string elem)
        {
            this.list.Insert(_top, elem);
        }
        public void Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            this.list.RemoveAt(_top);
        }
        public string Peek()
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
        public static Stack operator +(Stack a, string elem)
        {
            a.Push(elem);
            return a;
        }
        public static Stack operator --(Stack a)
        {
            a.Pop();
            return a;
        }
        public static bool operator true(Stack a)
        {
            if(a.Count == 0)
                return false;
            return true;
        }
        public static bool operator false(Stack a)
        {
            if(a.Count > 0)
                return true;
            return false;
        }
        public static Stack operator >(Stack a, Stack b)
        {
            a.list.Sort();
            b = a;
            return b;
        }
        public static Stack operator <(Stack a, Stack b)
        {
            a.list.Sort();
            b = a;
            return b;
        }
        public string Sum()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str +=" " + list[i];
            }
            return str;
        }
        public string Max()
        {
            string str1 = "";
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].Length > str1.Length)
                {
                    str1 = list[i];
                }
            }
            return str1;
        }
        public string Min()
        {
            string str2 = list[0];
            for (int i = 1; i < list.Count; i++)
            {
               if(list[i].Length < str2.Length)
               {
                    str2 = list[i];
               }
            }
            return str2;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
