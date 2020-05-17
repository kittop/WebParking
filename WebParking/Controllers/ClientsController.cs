using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebParking.Data;
using WebParking.Domain.Models;
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
                    MiddleName = form.MiddleName,
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
                }
                else
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

        [HttpGet("Edit/{id}")]
        public IActionResult Edit([FromRoute] long id)
        {
            var client = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
            {
                return NotFound("Не найден клиент с таким идентификатором!");
            }

            ClientEditViewModel clientEditViewModel = new ClientEditViewModel();
            clientEditViewModel.LastName = client.LastName;
            clientEditViewModel.FirstName = client.FirstName;
            clientEditViewModel.MiddleName = client.MiddleName;
            clientEditViewModel.Notes = client.Notes;
            clientEditViewModel.Passport = client.Document;
            clientEditViewModel.Telephone = client.Telephone;
            clientEditViewModel.DateOfBirth = client.DateOfBirth;
            clientEditViewModel.Id = client.Id;

            return View(clientEditViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(ClientEditViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", form);
            }

            var client = _context.Clients.FirstOrDefault(x => x.Id == form.Id);
            if (client == null)
            {
                return NotFound("Не найден клиент с таким идентификатором!");
            }

            try
            {
                client.FirstName = form.FirstName;
                client.LastName = form.LastName;
                client.MiddleName = form.MiddleName;
                client.Telephone = form.Telephone;
                client.DateOfBirth = form.DateOfBirth;
                client.Notes = form.Notes;
                client.Document = form.Passport;

                _context.Clients.Update(client);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                if (((Npgsql.PostgresException)exception.InnerException).ConstraintName == "IX_Clients_Document")
                {
                    ModelState.AddModelError(nameof(ClientCreateViewModel.Passport), "Данные документа, удостоверяющего личность, не уникальны!");
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(List));
        }

        [HttpPost("Delete")]
        public IActionResult Delete(long Id)
        {
            var client = _context.Clients.FirstOrDefault(x => x.Id == Id);
            if (client == null)
            {
                return NotFound("Не найден клиент с таким идентификатором!");
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return NoContent();
        }
    }
}