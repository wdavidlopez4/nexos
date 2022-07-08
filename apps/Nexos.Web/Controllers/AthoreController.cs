using Microsoft.AspNetCore.Mvc;
using Nexos.Web.Asserts.Stores;
using Nexos.Web.Models;

namespace Nexos.Web.Controllers
{
    public class AthoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, DateTime dateOfBirth, string email, string cityOfBirth)
        {
            AthoresAPI.Run();

            var result = await AthoresAPI.CreateAsync(new Athore 
            { 
                Name = name, 
                DateOfBirth = dateOfBirth, 
                Email = email,
                CityOfBirth = cityOfBirth 
            });

            return View();
        }
    }
}
