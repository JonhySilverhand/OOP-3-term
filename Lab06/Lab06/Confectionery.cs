using System;
using System.Collections.Generic;
using System.Text;

namespace Lab06
{
    public abstract class Confectionery
    {
        public string Name { get; set; }
        public int SugarCost { get; set; }
        public int Weight { get; set; }
        public virtual void TakeItem()
        {
            Console.WriteLine("Куплено кондитерское изделие");
        }
        /* Добавьте в интерфейсы (интерфейс) и абстрактный класс одноименные методы
         * Дайте в наследуемом классе им разную реализацию и вызовите эти методы */
        public abstract void GetConfectionary();
    }

    //Конфета
    public class Candy : Confectionery, IBuyConfectionery
    {   
        public string TypeCandy { get; set; }
        public ConfectioneryType _type = ConfectioneryType.Candy;
        public Candy()
        {
            Name = "Конфета";
            SugarCost = 23;
            Weight = 15;
        }
        public Candy(string name, int sugcost = 23, int weight = 15)
        {
            if (sugcost < 0 || sugcost > 50)
                throw new SugarCostExeption("Некорректное значение кол-ва сахара", "Candy", sugcost);
            if (weight < 0 || weight > 20)
                throw new ConfectionaryWeightExeption("Некорректная масса", "Candy", weight);
            Name = name;
            SugarCost = sugcost;
            Weight = weight;
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
        /*Во всех классах (иерархии) переопределить метод ToString(), 
         *который выводит информацию о типе объекта и его текущих значениях*/
        public override string ToString()
        {
            return $"Тип {this._type}, название - {this.Name}, содержание сахара - {this.SugarCost}";
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
    ////////////////////////////////////////////////////
    ////////////////////////////////////////////////////
   
    //Карамель
    public class Caramel : Candy, IBuyConfectionery
    {
        public new ConfectioneryType _type = ConfectioneryType.Caramel;
        public Caramel()
        {
            Name = "Roshen";
            SugarCost = 40;
            Weight = 8;
        }
        public Caramel(string name, int sugcost = 40, int weight = 8)
        {
            if (sugcost < 0 || sugcost > 50)
                throw new SugarCostExeption("Некорректное значение кол-ва сахара", "Caramel", sugcost);
            if (weight < 0 || weight > 20)
                throw new ConfectionaryWeightExeption("Некорректная масса", "Caramel", weight);
            Name = name;
            SugarCost = sugcost;
            Weight = weight;
        }
        public override void TakeItem()
        {
            Console.WriteLine("Взята карамель");
        }        void IBuyConfectionery.BuyConfectionary()
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
            return $"Тип {this._type}, название - {this.Name}, содержание сахара - {this.SugarCost}";
        }
    }
    //Шоколадная конфета
    public sealed class ChocolateCandy : Candy, IBuyConfectionery
    {
        public new ConfectioneryType _type = ConfectioneryType.Candy;
        public ChocolateCandy()
        {
            Name = "AlpenGold";
            SugarCost = 52;
            Weight = 10;
        }

        public ChocolateCandy(string name, int sugcost = 52, int weight = 10)
        {
            if (sugcost < 0 || sugcost > 60)
                throw new SugarCostExeption("Некорректное значение кол-ва сахара", "ChocolateCandy", sugcost);
            if (weight < 0 || weight > 20)
                throw new ConfectionaryWeightExeption("Некорректная масса", "ChocolateCandy", weight);
            Name = name;
            SugarCost = sugcost;
            Weight = weight;
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
            return $"Тип {this._type}, название - {this.Name}, содержание сахара - {this.SugarCost}";
        }
    }
    //Печенюшка
    public class Cookie : Confectionery, IBuyConfectionery
    {
        public ConfectioneryType _type = ConfectioneryType.Cookie;
        public Cookie()
        {
            Name = "Печенюшка";
            SugarCost = 11;
            Weight = 20;
        }
        public Cookie(string name, int sugcost = 11, int weight = 20)
        {
            if (sugcost < 0 || sugcost > 20)
                throw new SugarCostExeption("Некорректное значение кол-ва сахара", "Cookie", sugcost);
            if (weight < 0 || weight > 40)
                throw new ConfectionaryWeightExeption("Некорректная масса", "Cookie", weight);
            Name = name;
            SugarCost = sugcost;
            Weight = weight;
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
            return $"Тип {this._type}, название - {this.Name}, содержание сахара - {this.SugarCost}";
        }
    }
    //Коробка конфет
    public class BoxOfChocolates : Confectionery, IBuyConfectionery
    {
        public ConfectioneryType _type = ConfectioneryType.BoxOfChocolates;
        public BoxOfChocolates()
        {
            Name = "Коробка конфет";
            SugarCost = 310;
            Weight = 160;
        }
        public BoxOfChocolates(string name, int sugcost = 310, int weight = 160)
        {
            Name = name;
            SugarCost = sugcost;
            Weight = weight;
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
            return $"Тип {this._type}, название - {this.Name}, содержание сахара - {this.SugarCost}";
        }
    }
}
