namespace Nexos.Web.Models
{
    public class Book
    {
        public string Id { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Title { get; set; }

        public DateTime Anno { get; set; }

        public string Genero { get; set; }

        public int PageNumber { get; set; }
    }
}
