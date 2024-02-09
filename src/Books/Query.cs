namespace Books
{
    public class Query
    {
        public string Tag => "Book";

        public Book GetBook(string title) => new () { Title = title };
    }
}
