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
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
            List<Book> list;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                list = (List<Book>) jsonFormatter.ReadObject(stream);
            }

            return list.OrderBy(book => book.PublicationYear).First();
        }
    }
}