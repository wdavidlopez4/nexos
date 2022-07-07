using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Nexos.API
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ExceptionFilter(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not null)
            {
                context.Result = new JsonResult(new ExceptionDTO
                {
                    Mensaje = context.Exception.Message,
                    Tipo = context.Exception.GetType().ToString(),
                    Aplicacion = this.webHostEnvironment.ApplicationName
                });
            }
        }

        /// <summary>
        /// clase anidada para exepciones de las apis
        /// </summary>
        public class ExceptionDTO
        {
            public string Mensaje { get; set; }

            public string Tipo { get; set; }

            public string Aplicacion { get; set; }
        }
    }
}
