using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lab07
{
    class Json
    {
        public static void WriteList<T>(Stack<T> stack)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using StreamWriter sw = new StreamWriter(@"D:\\Лабораторные\\3_семестр\\ООП\\Lab07\\Lab07\\Data.json");
            using JsonWriter writer = new JsonTextWriter(sw);
            writer.Formatting = Formatting.Indented;
            serializer.Serialize(writer, stack.list);
        }
        public static void CreatePresentJson<T>(Stack<T> stack)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            };
            using var stream = new StreamReader(@"D:\\Лабораторные\\3_семестр\\ООП\\Lab07\\Lab07\\Data.json");
            string JsonData = stream.ReadToEnd();

            List<T> deserialisationList = JsonConvert.DeserializeObject<List<T>>(JsonData, settings);
            foreach (var item in deserialisationList)
                stack.Push(item);
        }
    }
}
