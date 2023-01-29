using System;
using System.Collections.Generic;
using System.Text;

namespace Lab07
{
    //4. Определить пользовательский класс, который будет использоваться в 
    //качестве параметра обобщения.Для пользовательского типа взять класс из
    //лабораторной №4 «Наследование». 
    public class Cookie
    {
        public string Name { get; set; }
        public Cookie()
        {
            Name = "Печенюшка";
        }
        public Cookie(string name)
        {
            Name = name;
        }
        public void TakeItem()
        {
            Console.WriteLine("Взята печенюшка");
        }
        public void BuyConfectionary()
        {
            Console.WriteLine("Куплена печенюшка");
        }
        public void GetConfectionary()
        {
            Console.WriteLine("Это печенюшка");
        }
        public override string ToString()
        {
            return $"Название - {this.Name}";
        }
    }
}
