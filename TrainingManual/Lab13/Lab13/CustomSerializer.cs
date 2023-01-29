using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Lab13
{
    public static class CustomSerializer
    {
        public static void Serialize<T>(T obj, string option, string path) where T : class
        {
            switch (option.ToUpper())
            {
                case "BIN":
                    {
                        var binaryFormatter = new BinaryFormatter();
                        using (var filestream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            binaryFormatter.Serialize(filestream, FileMode.OpenOrCreate);
                            Console.WriteLine("Object serialized");
                        }
                        break;
                    }
                case "SOAP":
                    {
                        var soapFormatter = new SoapFormatter();
                        using (var filestream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            soapFormatter.Serialize(filestream, FileMode.OpenOrCreate);
                            Console.WriteLine("Object serialized");
                        }
                        break;
                    }
                case "XML":
                    {
                        var xmlFormatter = new XmlSerializer(typeof(T));
                        using (var filestream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            xmlFormatter.Serialize(filestream, FileMode.OpenOrCreate);
                            Console.WriteLine("Object serialized");
                        }
                        break;
                    }
                case "JSON":
                    {
                        var jsonset = new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All 
                        };
                        string serialized = JsonConvert.SerializeObject(obj, jsonset);
                        using(var filestream = new StreamWriter(path))
                        {
                            filestream.Write(serialized);
                            Console.WriteLine("Object serialized");
                        }
                        break;
                    }
            }
        }

        public static void Deserialize<T>(ref T container, string option, string path) where T : class
        {
            switch (option.ToUpper())
            {
                case "BIN":
                    {
                        var binaryFormatter = new BinaryFormatter();
                        using (var filestream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = binaryFormatter.Deserialize(filestream) as T;
                        }
                        break;
                    }
                case "SOAP":
                    {
                        var soapFormatter = new SoapFormatter();
                        using (var filestream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = soapFormatter.Deserialize(filestream) as T;
                        }
                        break;
                    }
                case "XML":
                    {
                        var xmlFormatter = new XmlSerializer(typeof(T));
                        using (var filestream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = xmlFormatter.Deserialize(filestream) as T;
                        }
                        break;
                    }
                case "JSON":
                    {
                        var jsonset = new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All
                        };
                        using (var filestream = new StreamReader(path))
                        {
                            string json = filestream.ReadToEnd();
                            container = JsonConvert.DeserializeObject<T>(json, jsonset);
                        }
                        break;
                    }
            }
        }
    }
}
