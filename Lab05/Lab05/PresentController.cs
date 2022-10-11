using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lab05
{
    /*Определить управляющий класс-Контроллер, который управляет 
     *объектом- Контейнером и реализовать в нем запросы по варианту 
     *(Найти конфету в подарке, соответствующую заданному диапазону содержания сахара).
     *При необходимости используйте стандартные интерфейсы (IComparable, ICloneable,….)*/
    public static class PresentController
    {
        public static List<Confectionery> FindItemsBySugar (Present present, int SugarMin, int SugarMax)
        {
            return present.list.FindAll(x => x.SugarCost >= SugarMin && x.SugarCost <= SugarMax);
        }

        /*Добавьте в класс-контроллер метод, считывающий построчно 
         *текстовый файл, в котором хранятся данные вашего класса и инициализирует таким образом коллекцию*/

        public static void CreatePresentText(Present present)
        {
            StreamReader file = new StreamReader("D:\\Лабораторные\\3_семестр\\ООП\\Lab05\\Lab05\\List.txt");

            while(file.ReadLine() is string line)
            {
                switch(line)
                {
                    case "Caramel":
                        present.AddElem(new Caramel());
                        break;
                    case "ChocolateCandy":
                        present.AddElem(new ChocolateCandy());
                        break;
                    case "Cookie":
                        present.AddElem(new Cookie());
                        break;
                    case "BoxOfChocolates":
                        present.AddElem(new BoxOfChocolates());
                        break;
                    case "Candy":
                        present.AddElem(new Candy());
                        break;
                }
            }
        }

        /*Реализуйте еще один метод, который будет считывать данные из json файла и инициализировать коллекцию*/
        public static void CreatePresentJson(Present present)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            };
            using var stream = new StreamReader(@"D:\\Лабораторные\\3_семестр\\ООП\\Lab05\\Lab05\\Data.json");
            string JsonData = stream.ReadToEnd();

            List<Confectionery> deserialisationList = JsonConvert.DeserializeObject<List<Confectionery>>(JsonData, settings);
            foreach (var item in deserialisationList)
                present.AddElem(item);
        }
    }
}
