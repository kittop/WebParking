using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebParking.Data;
using WebParking.Domain.Models;
using WebParking.ViewModels;

namespace WebParking.Controllers
{
    [Controller]
    [Route("AutoCategories")]
    //[Authorize] // только авторизованные admin
    public class AutoCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var autoCategories = _context.AutoCategories.ToList();

            return View(autoCategories);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(AutoCategoriesCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var tempAutoCategory = new AutoCategory
                {
                    Name = form.Name,
                    Notes = form.Notes
                };

                _context.AutoCategories.Add(tempAutoCategory);
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
            var autoCategory = _context.AutoCategories.FirstOrDefault(x => x.Id == Id);
            if (autoCategory == null)
            {
                return NotFound("Не найдена категория с таким идентификатором!");
            }

            _context.AutoCategories.Remove(autoCategory);
            _context.SaveChanges();

            return NoContent();
        }
    }
}