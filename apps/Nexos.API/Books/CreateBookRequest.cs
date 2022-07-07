namespace Nexos.API.Books
{
    public class CreateBookRequest
    {
        public string Id { get; set; }

        public string AuthorId { get; set; }

        public string Title { get; set; }

        public DateTime Anno { get; set; }

        public string AuthorName { get; set; }

        public string Genero { get; set; }

        public int PageNumber { get; set; }
    }
}