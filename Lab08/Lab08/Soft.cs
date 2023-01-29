using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08
{
    public class Soft
    {
        public string Name { get; set; }
        public string Version { get; set; } = "1.0";
        public bool IsWorking { get; set; } = false;
        private Soft() { }
        public Soft(string name)
        {
            Name = name;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Приложение {Name}, версия: {Version} ");
            if(IsWorking)
                Console.WriteLine("Приложение запущено");
            else
                Console.WriteLine("Приложение не запущено");
        }

        public void StartWork() => IsWorking = true;
        public void EndWork() => IsWorking = false;
        public void ChangeVersion(string newVersion) => Version = newVersion;
    }
}
