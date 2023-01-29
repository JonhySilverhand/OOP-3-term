using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    [Serializable]
    public abstract class Confectionery
    {
        public string Name { get; set; }
        public virtual void TakeItem()
        {
            Console.WriteLine("Куплено кондитерское изделие");
        }
        public abstract void GetConfectionary();
    }
    [Serializable]
    //Конфета
    public class Candy : Confectionery, IBuyConfectionery
    {
        public string TypeCandy { get; set; }
        public Candy()
        {
            Name = "Конфета";
        }
        public Candy(string name)
        {
            Name = name;
        }
        public override void TakeItem()
        {
            Console.WriteLine("Взята конфета");
        }
        public void BuyConfectionary()
        {
            Console.WriteLine("Куплена конфета");
        }
        public override void GetConfectionary()
        {
            Console.WriteLine("Это конфета");
        }
        void IBuyConfectionery.GetConfectionary()
        {
            Console.WriteLine("Конфета");
        }

        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}";
        }
        public override bool Equals(object obj)
        {
            return this == obj;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    //Карамель
    public class Caramel : Candy, IBuyConfectionery
    {
        public Caramel()
        {
            Name = "Roshen";
            TypeCandy = "Карамель";
        }
        public Caramel(string name, string type)
        {
            Name = name;
            TypeCandy = type;
        }
        public override void TakeItem()
        {
            Console.WriteLine("Взята карамель");
        }
        void IBuyConfectionery.BuyConfectionary()
        {
            Console.WriteLine("Куплены карамель");
        }
        public override void GetConfectionary()
        {
            Console.WriteLine("Это карамель");
        }
        void IBuyConfectionery.GetConfectionary()
        {
            Console.WriteLine("Карамель");
        }
        public override string ToString()
        {
            return $"Тип {this.TypeCandy}, название - {this.Name}";
        }
    }
    [Serializable]
    //Шоколадная конфета
    public sealed class ChocolateCandy : Candy, IBuyConfectionery
    {
        public ChocolateCandy()
        {
            Name = "AlpenGold";
            TypeCandy = "Шоколадная конфета";
        }
        public ChocolateCandy(string name, string type)
        {
            Name = name;
            TypeCandy = type;
        }
        public override void TakeItem()
        {
            Console.WriteLine("Взята шоколадная конфета");
        }
        void IBuyConfectionery.BuyConfectionary()
        {
            Console.WriteLine("Куплена шоколадная конфета");
        }
        public override void GetConfectionary()
        {
            Console.WriteLine("Это шоколадная конфета");
        }
        void IBuyConfectionery.GetConfectionary()
        {
            Console.WriteLine("Шоколадная конфета");
        }
        public override string ToString()
        {
            return $"Тип {this.TypeCandy}, название - {this.Name}";
        }
    }
    //Печенюшка
    public class Cookie : Confectionery, IBuyConfectionery
    {
        public Cookie()
        {
            Name = "Печенюшка";
        }
        public Cookie(string name)
        {
            Name = name;
        }
        public override void TakeItem()
        {
            Console.WriteLine("Взята печенюшка");
        }
        public void BuyConfectionary()
        {
            Console.WriteLine("Куплена печенюшка");
        }
        public override void GetConfectionary()
        {
            Console.WriteLine("Это печенюшка");
        }
        void IBuyConfectionery.GetConfectionary()
        {
            Console.WriteLine("Печенюшка");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}";
        }
    }
    [Serializable]
    //Коробка конфет
    public class BoxOfChocolates : Confectionery, IBuyConfectionery
    {
        public BoxOfChocolates()
        {
            Name = "Коробка конфет";
        }
        public BoxOfChocolates(string name)
        {
            Name = name;
        }
        public override void TakeItem()
        {
            Console.WriteLine("Взята коробка конфет");
        }
        public void BuyConfectionary()
        {
            Console.WriteLine("Куплена коробка конфет");
        }
        public override void GetConfectionary()
        {
            Console.WriteLine("Это коробка конфет");
        }
        void IBuyConfectionery.GetConfectionary()
        {
            Console.WriteLine("Коробка конфет");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}";
        }
    }
}
