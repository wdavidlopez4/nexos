using Nexos.Web.Asserts.Request;
using Nexos.Web.Asserts.Url;
using Nexos.Web.Models;
using System.Net.Http.Headers;

namespace Nexos.Web.Asserts.Stores
{
    public class AthoresAPI
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

        public static async Task<Uri> CreateAsync(Athore athore)
        {
            var modelRequest = new AthoreRequest
            {
                CityOfBirth = athore.CityOfBirth,
                DateOfBirth = athore.DateOfBirth,
                Email = athore.Email,
                Name = athore.Name,
            };

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"{URLAPI.ACTION_CREATE_ATHORE}",
                modelRequest);


            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

    }
}
