using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace Adapter
{
    public class Converter
    {
        public string SerializeBooksXml(List<Book> books)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            string booksXml;

            using (var stream = new StringWriter())
            {
                serializer.Serialize(stream, books);
                return stream.ToString();
            }
        }
        public List<Book> DeserializeBooksXml(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

            using (var stream = new StringReader(xml))
            {
                return (List<Book>)serializer.Deserialize(stream);
            }
        }

        public string SerializeBooksJson(List<Book> books)
        {
            string json;
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));

            using (var stream = new MemoryStream())
            {
                jsonFormatter.WriteObject(stream, books);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }

            }

            return json;
        }

        public List<Book> DeserializeBooksJson(string json)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (List<Book>)jsonFormatter.ReadObject(stream);
            }
        }
    }
}