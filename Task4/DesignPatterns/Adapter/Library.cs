using System.Collections.Generic;

namespace Adapter
{
    public class Library
    {
        public string GetBooksXML()
        {
            var books = GetBooks();
            var converter = new Converter();
            return converter.SerializeBooksXml(books);
        }

        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book {Author = "Pushkin", Name = "Fairy tale", PublicationYear = 1890},
                new Book {Author = "Pushkin", Name = "Fairy tale. V2", PublicationYear = 1893}
            };
        }


    }
}
