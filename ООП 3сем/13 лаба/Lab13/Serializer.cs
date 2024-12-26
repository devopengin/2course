using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace Lab13
{
    public class SerializerBIN<T> : ISerializer<T> where T : GeographicalEntity
    {
        public void Serializer(string filename, T obj)
        {
            BinaryFormatter binaryFormatter = new();

            using (FileStream writer = new(filename, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(writer, obj);
                Console.WriteLine($"Объект {obj.Name} сериализован");
            }

        }
        public T Deserializer(string filename)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream reader = new(filename, FileMode.OpenOrCreate))
            {
                T obj = (T)binaryFormatter.Deserialize(reader);
                Console.WriteLine($"Объект {obj.Name} десериализован из файла {filename}");
                return obj;
            }

        }
    }

    public class SerializerJSON<T> : ISerializer<T> where T : GeographicalEntity
    {
        public void Serializer(string filename, T obj)
        {
            using (FileStream writer = new(filename, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(writer, obj);
                Console.WriteLine($"Объект {obj.Name} сериализован");
            }
        }
        public T Deserializer(string filename)
        {
            using (FileStream reader = new FileStream(filename, FileMode.OpenOrCreate))
            {
                T obj = JsonSerializer.Deserialize<T>(reader);
                Console.WriteLine($"Объект {obj.Name} десериализован из файла {filename}");
                return obj;
            }
        }
    }

    public class SerializerXML<T> : ISerializer<T> where T : GeographicalEntity
    {
        private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

        public void Serializer(string filename, T obj) { 
            using(FileStream writer = new(filename, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(writer, obj);
                Console.WriteLine($"Объект {obj.Name} сериализован");
            }
        }
        public T Deserializer(string filename) {
            using(FileStream reader = new(filename, FileMode.OpenOrCreate))
            {
                T res = (T)xmlSerializer.Deserialize(reader);
                Console.WriteLine($"Объект {res.Name} десериализован из файла {filename}");
                return res;
            }
        }
    }

    public class SerializerSOAP<T> : ISerializer<T> where T : Ocean
    {
        SoapFormatter formatter = new();
        public void Serializer(string filename, T obj)
        {

            using (FileStream writer = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(writer, obj);
                Console.WriteLine($"Объект {obj.Name} сериализован");
            }
        }

        public T Deserializer(string filename)
        {
            using (FileStream reader = new FileStream(filename, FileMode.OpenOrCreate))
            {
                object obj = formatter.Deserialize(reader);
                T result = (T)obj;
                Console.WriteLine($"Объект {result.Name} десериализован из файла {filename}");
                return result;
            }
        }
    }

}
