namespace LibraryForSimpleTests
{
    public class Library
    {
        private readonly List<Book> _books = new();
        private readonly Dictionary<User, List<Book>> _userBooks = new();

        public void AddBook(Book book) => _books.Add(book);

        public void RemoveBook(Book book) => _books.Remove(book);

        public bool HasBook(Book book) => _books.Contains(book);

        public void BorrowBook(User user, Book book)
        {
            if (!_books.Contains(book)) return;

            _books.Remove(book);
            if (!_userBooks.ContainsKey(user))
                _userBooks[user] = new List<Book>();

            _userBooks[user].Add(book);
        }

        public void ReturnBook(User user, Book book)
        {
            if (_userBooks.TryGetValue(user, out var books))
            {
                if (books.Contains(book))
                {
                    books.Remove(book);
                    _books.Add(book);
                }
            }
        }

        public List<Book> GetBooksByUser(User user) =>
            _userBooks.TryGetValue(user, out var books) ? books : new();
    }
}