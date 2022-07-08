using Nexos.Web.Asserts.Request;
using Nexos.Web.Asserts.Url;
using Nexos.Web.Models;
using System.Net.Http.Headers;

namespace Nexos.Web.Asserts.Stores
{
    public class BookAPI
    {
        private static HttpClient client = new HttpClient();

        public static void Run()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri($"{URLAPI.SERVE}");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Uri> CreateAsync(Book book)
        {
            var modelRequest = new BookRequest
            {
                Anno = book.Anno,
                AuthorId = book.AuthorId,
                Genero = book.Genero,
                AuthorName = book.AuthorName,
                Title = book.Title,
                PageNumber = book.PageNumber
            };

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"{URLAPI.ACTION_CREATE_BOOK}",
                modelRequest);


            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public static async Task<List<Book>> GetAllAsync(string authorName, string title, DateTime anno)
        {
            List<Book> autores = null;
            string url = "";

            if(authorName is not null)
                url = $"{URLAPI.ACTION_GETALL_BOOK}?authorName={authorName}";
            else if (authorName is not null)
                url = $"{URLAPI.ACTION_GETALL_BOOK}?title={title}";

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                autores = await response.Content.ReadFromJsonAsync<List<Book>>();
            }
            return autores;
        }
    }
}
