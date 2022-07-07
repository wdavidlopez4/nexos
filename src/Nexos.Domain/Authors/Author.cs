using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Domain.Authors
{
    public class Author : Aggregate
    {
        public AuthorId Id { get; private set; }

        public string Name { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public AuthorEmail Email { get; private set; }

        public string CityOfBirth { get; private set; }

        /// <summary>
        /// for ef
        /// </summary>
        private Author() : base()
        {

        }

        private Author(AuthorId id, string name, DateTime dateOfBirth, AuthorEmail email, string cityOfBirth)
            :base()
        {
            if (id is null)
                throw new ArgumentNullException("id");
            else if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("nombre");
            else if (email is null)
                throw new ArgumentException("correo");
            else if (string.IsNullOrEmpty(cityOfBirth))
                throw new ArgumentNullException("ciudad de naciemiento");

            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            CityOfBirth = cityOfBirth;
        }

        public static Author Build(AuthorId id, string name, DateTime dateOfBirth, AuthorEmail email, string cityOfBirth)
        {
            return new Author(id, name, dateOfBirth, email, cityOfBirth);
        }
    }
}
