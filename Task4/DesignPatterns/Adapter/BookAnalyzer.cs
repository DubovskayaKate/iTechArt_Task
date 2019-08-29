using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Adapter
{
    public class BookAnalyzer
    {
        public Book GetOldestBook(string json)
        {
            var converter = new Convertеr();
            return converter.DeserializeBooksJson(json).OrderBy(book => book.PublicationYear).First();
        }


    }
}