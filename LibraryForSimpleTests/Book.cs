namespace LibraryForSimpleTests
{
    public class Book
    {
        public string ISBN { get; }
        public string Title { get; }
        public string Author { get; }

        public Book(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
        }

        public override bool Equals(object obj) =>
            obj is Book other && ISBN == other.ISBN;
        public override int GetHashCode() =>
            ISBN?.GetHashCode() ?? 0;
    }
}