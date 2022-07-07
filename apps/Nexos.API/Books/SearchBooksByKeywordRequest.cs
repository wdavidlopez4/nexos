namespace Nexos.API.Books
{
    public class SearchBooksByKeywordRequest
    {
        public string AuthorName { get; set; }

        public string Title { get; set; }

        public DateTime? Anno { get; set; }
    }
}