using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebParking.Data;
using WebParking.Domain.Models;
using WebParking.ViewModels;

namespace WebParking.Controllers
{
    [Controller]
    [Route("ClientCategories")]
    //[Authorize] // только авторизованные
    public class ClientCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var clientCategories = _context.ClientCategories.ToList();

            return View(clientCategories);
        }

        [HttpGet("{id}")]
        public IActionResult Detail(long id)
        {
            var clientCategories = _context.ClientCategories.Include(x => x.Clients).FirstOrDefault(x => x.Id == id);

            return View(clientCategories);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(ClientCategoriesCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var tempClientCategory = new ClientCategory
                {
                    Name = form.Name,
                    Notes = form.Notes
                };

                _context.ClientCategories.Add(tempClientCategory);
                _context.SaveChanges();

            }
            catch (Exception exception)
            {
                //if (((Npgsql.PostgresException)exception.InnerException).ConstraintName == "IX_Clients_Document")
                //{
                //    ModelState.AddModelError(nameof(ClientCreateViewModel.Passport), "Данные документа, удостоверяющего личность, не уникальны!");
                //}
                //else
                //{
                throw;
                //}
            }

            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            return RedirectToAction(nameof(List));
        }

        [HttpPost("Delete")]
        public IActionResult Delete(long Id)
        {
            var clientCategory = _context.ClientCategories.FirstOrDefault(x => x.Id == Id);
            if (clientCategory == null)
            {
                return NotFound("Не найдена категория с таким идентификатором!");
            }

            _context.ClientCategories.Remove(clientCategory);
            _context.SaveChanges();

            return NoContent();
        }
    }
}