using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebParking.Data;
using WebParking.Models;

namespace WebParking.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var con = _context.Database.GetDbConnection();
            //var com = con.CreateCommand();
            //com.CommandText = "123214";
            //var reader = com.ExecuteReader();
            //while (reader.Read())
            //{

            //}
            //_context.Clients.Add(new Client() {FirstName = "123", LastName = "321"});
            //_context.SaveChanges();

            //var clients = _context.Clients.ToList();
            return View();
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