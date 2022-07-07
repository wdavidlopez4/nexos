using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexos.Application.Authors.CreateAuthor;
using Nexos.Application.Books.CreateBook;
using Nexos.Application.Books.SearchBooksByKeyword;
using Nexos.Domain;
using Nexos.Domain.Authors;
using Nexos.Domain.Books;
using Nexos.Infrastructure.Autors;
using Nexos.Infrastructure.Books;
using Nexos.Infrastructure.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Infrastructure
{
    public class NexosStartup
    {
        public static void SetUp(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureIOC(services);
            ConfigureMediador(services);
            ConfigureMapper(services);
        }

        private static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NexosDbContext>(options =>
            options.UseOracle(
                    configuration.GetConnectionString("NexosConnectionString")));
        }

        private static void ConfigureIOC(IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepositoryOracle>();
            services.AddScoped<IBooksRepository, BooksRepositoryOracle>();
            services.AddScoped<IMapObject, MapObject>();
        }

        private static void ConfigureMediador(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateAuthorCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateBookCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SearchBooksByKeywordQuery).GetTypeInfo().Assembly);
        }

        private static void ConfigureMapper(IServiceCollection services)
        {
            //mapeo de entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
