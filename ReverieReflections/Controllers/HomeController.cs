using Microsoft.AspNetCore.Mvc;
using ReverieReflections.Data;
using ReverieReflections.Models;
using System.Diagnostics;

namespace ReverieReflections.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ApplicationDbContext Db { get; }

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            Db = db;
        }
        public IActionResult Index(YazarMakaleViewModel vm)
        {
            vm.Makaleler = Db.Makale.ToList();
            vm.Kisi = Db.Users.ToList();

            return View(vm);
        }

 

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}