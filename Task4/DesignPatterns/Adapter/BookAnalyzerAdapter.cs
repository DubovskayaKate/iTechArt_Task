using System.Collections.Generic;

namespace Adapter
{
    public class BookAnalyzerAdapter : ITarget
    {
        private readonly BookAnalyzer _bookAnalyzer;

        public BookAnalyzerAdapter(BookAnalyzer bookAnalyzer)
        {
            _bookAnalyzer = bookAnalyzer;
        }

        public Book GetOldestBook(string xml)
        {
            var converter = new Converter();
            List<Book> books = converter.DeserializeBooksXml(xml);
            return _bookAnalyzer.GetOldestBook(converter.SerializeBooksJson(books));
        }
    }
}