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

        [HttpGet]
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

        [HttpPost]
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
                };

                _context.Clients.Add(tempClient);
                _context.SaveChanges();
     
            }
            catch (Exception exception)
            {
                if (((Npgsql.PostgresException)exception.InnerException).ConstraintName == "IX_Clients_Document")
                {
                    ModelState.AddModelError(nameof(ClientCreateViewModel.Passport), "Данные документа, удостоверяющего личность, не уникальны!");
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

            return RedirectToAction(nameof(List));
        }

        [HttpPost("Edit/{id}")]
        public IActionResult Edit([FromRoute] long id)
        {
            return Ok(new { Pepa = id, meow = true });
        }
    }
}