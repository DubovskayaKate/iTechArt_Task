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
            var converter = new Convertеr();
            List<Book> books = converter.DeserializeBooksXml(xml);
            return _bookAnalyzer.GetOldestBook(converter.SerializeBooksJson(books));
        }
    }
}