namespace Nexos.API.Authors
{
    public class CreateAuthorsRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string CityOfBirth { get; set; }
    }
}