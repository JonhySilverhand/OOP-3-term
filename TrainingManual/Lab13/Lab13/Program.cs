using System;

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
        }
    }
}
