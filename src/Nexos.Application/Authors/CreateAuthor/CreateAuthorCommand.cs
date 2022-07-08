using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Application.Authors.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get;  set; }

        public string Email { get; set; }

        public string CityOfBirth { get;  set; }
    }
}
