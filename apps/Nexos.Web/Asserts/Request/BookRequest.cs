namespace Nexos.Web.Asserts.Request
{
    public class BookRequest
    {
        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Title { get; set; }

        public DateTime Anno { get; set; }

        public string Genero { get; set; }

        public int PageNumber { get; set; }
    }
}
