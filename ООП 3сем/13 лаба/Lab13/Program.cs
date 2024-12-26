using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;

namespace Lab13
{
    public class Program
    {
        static void Main(string[] args)
        {

            Ocean pacific = new("Тихий океан", 10994, 10000);
            Ocean pacific1 = new("fgdgfdg", 2132, 23234);
            Ocean pacific3 = new("dfgdgdfgddgf", 132, 23232);
            Ocean pacific4 = new("gddfgfdg", 13, 33434);
            Continent cont = new("dfggf", 34343);

            //a
            //SerializerBIN<Ocean> serializerBIN = new SerializerBIN<Ocean>();
            //serializerBIN.Serializer("pacific1.bin", pacific);
            //Ocean desearilizeBIN = serializerBIN.Deserializer("pacific1.bin");
            //Console.WriteLine(desearilizeBIN.ToString());
            //b
            //SerializerSOAP<Ocean> serializerSOAP = new SerializerSOAP<Ocean>();
            //serializerSOAP.Serializer("pacific1.soap", pacific);
            //Ocean deserializedSOAP = serializerSOAP.Deserializer("pacific.soap");
            //Console.WriteLine(deserializedSOAP.ToString());

            //с
            //SerializerJSON<Ocean> serializerJSON = new SerializerJSON<Ocean>();
            //serializerJSON.Serializer("pacific1.json", pacific);
            //Ocean desearilizeJSON = serializerJSON.Deserializer("pacific1.json");

            //d
            SerializerXML<Continent> serializerXML = new SerializerXML<Continent>();
            serializerXML.Serializer("cont.xml", cont);
            Continent desearilizeXML = serializerXML.Deserializer("cont.xml");

            //2

            //XmlSerializer serializer = new XmlSerializer(typeof(List<Ocean>));
            //List<Ocean> oceans = new List<Ocean>();
            //oceans.Add(pacific);
            //oceans.Add(pacific1);
            //oceans.Add(pacific3);
            //oceans.Add(pacific4);
            //using (FileStream writer = new FileStream("Oceans.xml", FileMode.OpenOrCreate))
            //{
            //    serializer.Serialize(writer, oceans);
            //}
            //Console.WriteLine("Коллекция была сериализована");

            //using (FileStream reader = new FileStream("Oceans.xml", FileMode.OpenOrCreate))
            //{
            //    List<Ocean> newOceans = (List<Ocean>)serializer.Deserialize(reader);
            //    foreach (var item in newOceans)
            //    {
            //        Console.WriteLine($"Десериализован : {item}");
            //    }
            //}
        //    Console.WriteLine("---------------------------");
        //    XmlDocument xmlDocument = new XmlDocument();
        //    xmlDocument.Load("Oceans.xml");

        //    XmlElement? root = xmlDocument.DocumentElement;
        //    if (root != null)
        //    {
        //        XmlNodeList? allNodes = root.SelectNodes("Ocean");
        //        foreach (XmlNode node in allNodes)
        //        {
        //            XmlAttribute? nameAttr = node.Attributes?["NameOfEntity"];
        //            XmlNode? valueAttr = node["Deepth"];
        //            if (nameAttr != null && valueAttr != null)
        //            {
        //                Console.WriteLine($"Название географического объекта: {nameAttr.Value}");
        //                Console.WriteLine($"Глубина окена: {valueAttr.InnerText}");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Ошибка при извлечении данных для океана.");
        //            }

        //        }
        //    }

        //    //3
        //    Console.WriteLine("---------------------------");
        //    XmlDocument xml = new();
        //    xml.Load("Oceans.xml");

        //    XmlNodeList oceanNodes = xml.SelectNodes("/ArrayOfOcean/Ocean");
        //    foreach (XmlNode node in oceanNodes)
        //    {
        //        Console.WriteLine($"Ocean: {node.Attributes["NameOfEntity"].Value}");
        //    }

        //    Console.WriteLine("---------------------------");

        //    XmlNodeList nameAttrNodes = xml.SelectNodes("/ArrayOfOcean/Ocean/@NameOfEntity");
        //    foreach (XmlNode node in nameAttrNodes)
        //    {
        //        Console.WriteLine($"Названия океана: {node.Value}");
        //    }

        //    Console.WriteLine("---------------------------");

        //    XmlNodeList costNodes = xml.SelectNodes("/ArrayOfOcean/Ocean/Cost");
        //    foreach (XmlNode node in costNodes)
        //    {
        //        Console.WriteLine($"Цена: {node.InnerText}");
        //    }

        //    Console.WriteLine("---------------------------");

        //    XmlNodeList deepthNodes = xml.SelectNodes("/ArrayOfOcean/Ocean/Deepth");
        //    foreach (XmlNode node in deepthNodes)
        //    {
        //        Console.WriteLine($"глубина: {node.InnerText}");
        //    }


        //    //4
        //    Console.WriteLine("---------------------------");
        //    XDocument docXML = XDocument.Load("Oceans.xml");
        //    var oceansXML = docXML.Element("ArrayOfOcean")?
        //    .Elements("Ocean").Where(p => p.Element("Cost")?.Value == "10000" && p.Element("Deepth")?.Value == "10994")
        //    .Select(p => new
        //    {
        //        name = p.Attribute("NameOfEntity")?.Value,
        //        cost = p.Element("Cost")?.Value,
        //        deepth = p.Element("Deepth")?.Value
        //    });

        //    if (oceansXML != null && oceansXML.Any()) 
        //    {
        //        foreach (var ocean in oceansXML)
        //        {
        //            Console.WriteLine($"Название океана: {ocean.name}  Цена: {ocean.cost}, Глубина : {ocean.deepth}");
        //        }
        //    }
        }
    }
}
