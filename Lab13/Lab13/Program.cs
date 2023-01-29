using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            var choco = new ChocolateCandy("Алёнка", "Конфета");
            Console.ForegroundColor = ConsoleColor.Yellow;
            //BIN
            string path = @"D:\Лабораторные\3_семестр\ООП\Lab13\Lab13\BIN.bin";
            ChocolateCandy bincont = new ChocolateCandy();
            CustomSerializer.Serialize(choco, "bin", path);
            CustomSerializer.Deserialize(ref bincont, "bin", path);
            Console.WriteLine($"▬▬▬▬ Deserialization from .bin ▬▬▬▬\n{bincont.ToString()}\n");
            //SOAP
            path = @"D:\Лабораторные\3_семестр\ООП\Lab13\Lab13\Soap.soap";
            ChocolateCandy soapcont = new ChocolateCandy();
            CustomSerializer.Serialize(choco, "soap", path);
            CustomSerializer.Deserialize(ref soapcont, "soap", path);
            Console.WriteLine($"▬▬▬▬ Deserialization from .soap ▬▬▬▬\n{soapcont.ToString()}\n");
            //XML
            path = @"D:\Лабораторные\3_семестр\ООП\Lab13\Lab13\XML.xml";
            ChocolateCandy xmlcont = new ChocolateCandy();
            CustomSerializer.Serialize(choco, "xml", path);
            CustomSerializer.Deserialize(ref xmlcont, "xml", path);
            Console.WriteLine($"▬▬▬▬ Deserialization from .xml ▬▬▬▬\n{xmlcont.ToString()}\n");
            //JSON
            path = @"D:\Лабораторные\3_семестр\ООП\Lab13\Lab13\Json.json";
            ChocolateCandy jsoncont = new ChocolateCandy();
            CustomSerializer.Serialize(choco, "json", path);
            CustomSerializer.Deserialize(ref jsoncont, "json", path);
            Console.WriteLine($"▬▬▬▬ Deserialization from .json ▬▬▬▬\n{jsoncont.ToString()}\n");

            /*2. Создайте коллекцию (массив) объектов и выполните сериализацию/десериализацию – 
             * возможность сохранения и загрузки списка объектов в/из файла. */
            Console.ForegroundColor = ConsoleColor.White;

            var candies = new List<Confectionery>();
            var candiesFile = new List<Confectionery>();

            var candy1 = new Candy("Столичная");
            var candy2 = new ChocolateCandy();
            var candy3 = new BoxOfChocolates("Bonjour");

            candies.Add(candy1);
            candies.Add(candy2);
            candies.Add(candy3);

            path = @"D:\Лабораторные\3_семестр\ООП\Lab13\Lab13\CandiesJson.json";
            CustomSerializer.Serialize(candies, "json", path);
            Console.WriteLine("▬▬▬ Deserialization from json ▬▬▬");
            CustomSerializer.Deserialize(ref candiesFile, "json", path);

            foreach (var candy in candiesFile)
            {
                Console.WriteLine(candy.ToString());
            }

            /*3. Используя XPath напишите два селектора для вашего XML документа*/
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"D:\Лабораторные\3_семестр\ООП\Lab13\Lab13\XML.xml");
            var xRoot = xmlDocument.DocumentElement;
            var nodes = xmlDocument.SelectNodes("*");
            foreach (object n in nodes)
                Console.WriteLine((n as XmlNode).Name);

            Console.WriteLine();
            var nameNodes = xRoot.SelectNodes("Name");
            foreach (object nameNode in nameNodes)
                Console.WriteLine((nameNode as XmlNode).InnerText);
            Console.WriteLine();

            /*4. Используя Linq to XML (или Linq to JSON) создайте новый xml (json) - документ и напишите несколько запросов*/

            Console.ForegroundColor = ConsoleColor.Red;

            XDocument GunsXML = new XDocument();
            XElement root = new XElement("storage");

            XElement weapon = new XElement("weapon");
            XAttribute type = new XAttribute("type", "pistol");
            XElement name = new XElement("name");
            XElement caliber = new XElement("caliber");
            name.Value = "TT ";
            caliber.Value = "7.62mm";
            weapon.Add(type);
            weapon.Add(name);
            weapon.Add(caliber);
            root.Add(weapon);

            weapon = new XElement("weapon");
            type = new XAttribute("type", "rifle");
            name = new XElement("name");
            caliber = new XElement("caliber");
            name.Value = "AK-74m ";
            caliber.Value = "5.45mm";
            weapon.Add(type);
            weapon.Add(name);
            weapon.Add(caliber);
            root.Add(weapon);

            weapon = new XElement("weapon");
            type = new XAttribute("type", "pistol");
            name = new XElement("name");
            caliber = new XElement("caliber");
            name.Value = "Glock-17 ";
            caliber.Value = "9mm";
            weapon.Add(type);
            weapon.Add(name);
            weapon.Add(caliber);
            root.Add(weapon);

            weapon = new XElement("weapon");
            type = new XAttribute("type", "sniper rifle");
            name = new XElement("name");
            caliber = new XElement("caliber");
            name.Value = "СВД-с ";
            caliber.Value = "7.62mm";
            weapon.Add(type);
            weapon.Add(name);
            weapon.Add(caliber);
            root.Add(weapon);

            weapon = new XElement("weapon");
            type = new XAttribute("type", "shotgun");
            name = new XElement("name");
            caliber = new XElement("caliber");
            name.Value = "MP-153 ";
            caliber.Value = "12mm";
            weapon.Add(type);
            weapon.Add(name);
            weapon.Add(caliber);
            root.Add(weapon);

            GunsXML.Add(root);
            GunsXML.Save(@"D:\Лабораторные\3_семестр\ООП\Lab13\Lab13\gunsXML.xml");

            Console.WriteLine("Введите тип оружия: ");
            string typeXml = Console.ReadLine();
            var elem = root.Elements("weapon");

            foreach (var item in elem)
            {
                if(item.Attribute("type").Value == typeXml)
                    Console.WriteLine(item.Value);
                    
            }

        }
    }
}
