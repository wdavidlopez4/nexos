using Microsoft.AspNetCore.Mvc;
using Nexos.Web.Asserts.Stores;
using Nexos.Web.Models;

namespace Nexos.Web.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Book book)
        {
            TempData["AuthorName"] = book.AuthorName;
            TempData["Title"] = book.Title;
            TempData["Anno"] = book.Anno;

            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(List<Book> books)
        {
            string authorName = null;
            string title = null;
            string anno = null;

            if (TempData["AuthorName"] is not null)
                authorName = TempData["AuthorName"].ToString();

            if (TempData["Title"] is not null)
                title = TempData["Title"].ToString();

            if (TempData["anno"] is not null)
                anno = TempData["anno"].ToString();


            BookAPI.Run();
            var result = await BookAPI.GetAllAsync(authorName, title, DateTime.Parse(anno));

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string authorId, string authorName, string title, 
            DateTime anno, string genero, int pageNumber)
        {
            BookAPI.Run();

            var result = await BookAPI.CreateAsync(new Book
            {
                AuthorId = authorId,
                AuthorName = authorName,
                Title = title,
                Anno = anno,
                Genero = genero,
                PageNumber = pageNumber
            });

            return View();
        }
    }
}
