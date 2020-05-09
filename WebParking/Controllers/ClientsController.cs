using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebParking.Data;
using WebParking.Domain;
using WebParking.ViewModels;

namespace WebParking.Controllers
{ 
    [Controller]
    [Route("Clients")]
    public class ClientsController : Controller
    {
        private ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var clients = _context.Clients.ToList();

            return View(clients);
        }

        [HttpGet("Create")]
        public IActionResult CreatePage()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(ClientCreateViewModel form)
        {
            Client tempClient = new Client {FirstName = form.FirstName, LastName = form.LastName};
            _context.Clients.Add(tempClient);
            _context.SaveChanges();
            return Ok(tempClient);
        }

        [HttpPost("Edit")]
        public IActionResult Edit([FromQuery] long id)
        {
            return Ok(new { Pepa = id, meow = true});
        }
    }
}
