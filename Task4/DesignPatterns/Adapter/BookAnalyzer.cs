using System.Linq;

namespace Adapter
{
    public class BookAnalyzer
    {
        public Book GetOldestBook(string json)
        {
            var converter = new Converter();
            return converter.DeserializeBooksJson(json).OrderBy(book => book.PublicationYear).First();
        }


    }
}