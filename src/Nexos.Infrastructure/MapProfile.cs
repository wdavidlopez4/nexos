using AutoMapper;
using Nexos.Application.Books.SearchBooksByKeyword;
using Nexos.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Infrastructure.Startup
{
    public class MapProfile : Profile
    {
        public MapProfile(): base()
        {
            this.CreateMap<Book, SearchBooksByKeywordDTO>();
        }
    }
}
