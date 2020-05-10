using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebParking.Data;
using WebParking.Domain;
using WebParking.ViewModels;

namespace WebParking.Controllers
{
    [Controller]
    [Route("Clients")]
    //[Authorize] // только авторизованные
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult CreatePost(ClientCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var tempClient = new Client
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Telephone = form.Telephone,
                    DateOfBirth = form.DateOfBirth,
                    Notes = form.Notes,
                    Document = form.Passport,
                    DocumentType = DocumentType.Passport
                    //Creation = System.DateTime.Now
                };

                _context.Clients.Add(tempClient);
                _context.SaveChanges();
                return Ok(tempClient);
            }
            catch (Exception exception)
            {
                if (((Npgsql.PostgresException)exception.InnerException).ConstraintName == "IX_Clients_Document")
                {
                    ModelState.AddModelError("123", "Данные документа, удостоверяющего личность, не уникальны!");
                    //return BadRequest("Данные документа, удостоверяющего личность, не уникальны!");
                } else
                {
                    throw;
                }
            }

            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            return Ok();
        }

        [HttpPost("Edit")]
        public IActionResult Edit([FromQuery] long id)
        {
            return Ok(new { Pepa = id, meow = true });
        }
    }
}