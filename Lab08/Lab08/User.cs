using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08
{
    //1. Используя делегаты(множественные) и события промоделируйте
    //ситуации, приведенные в таблице ниже.Можете добавить новые типы(классы), 
    //если существующих недостаточно.При реализации методов везде где возможно
    //использовать лямбда-выражения

    public delegate void Upgrade(string str);
    public delegate void Work();
    public class User
    {
        public static event Upgrade OnUprade;
        public static event Work StartWork;
        public static event Work EndWork;
        public static void StartWorkWithSoft(Soft soft)
        {
            Console.WriteLine("Работа начата...");
            User.StartWork += soft.StartWork;
            StartWork.Invoke();
        }
        public static void EndWorkWithSoft(Soft soft)
        {
            Console.WriteLine("Работа прекращена...");
            User.EndWork += soft.EndWork;
            EndWork.Invoke();
        }
        public static void UpgradeSoft(Soft soft, string newVersion)
        {
            Console.WriteLine("Обновление версии...");
            User.OnUprade += soft.ChangeVersion;
            OnUprade.Invoke(newVersion);
        }
    }
}
