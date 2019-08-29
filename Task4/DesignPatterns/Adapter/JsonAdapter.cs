using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Adapter
{
    public class JsonAdapter : ITarget
    {
        private readonly BookAnalyzer _bookAnalyzer;

        public JsonAdapter(BookAnalyzer bookAnalyzer)
        {
            _bookAnalyzer = bookAnalyzer;
        }

        public Book GetOldestBook(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

            List<Book> list;

            using (var stream = new StringReader(xml))
            {
                list = (List<Book>) serializer.Deserialize(stream);
            }

            string json;
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));

            using (var stream = new MemoryStream())
            {
                jsonFormatter.WriteObject(stream, list);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }

            }

            Console.WriteLine(json);


            return _bookAnalyzer.GetOldestBook(json);
        }
    }
}