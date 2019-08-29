using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Adapter
{
    public class Library
    {
        public string GetBooksXML()
        {
            var books = new List<Book>
            {
                new Book {Author = "Pushkin", Name = "Fairy tale", PublicationYear = 1890},
                new Book {Author = "Pushkin", Name = "Fairy tale. V2", PublicationYear = 1893}
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            string booksXml;

            using (var stream = new StringWriter())
            {
                serializer.Serialize(stream, books);
                booksXml = stream.ToString();
            }

            return booksXml;
        }
    }
}
