using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebParking.Data;
using WebParking.Domain.Models;
using WebParking.ViewModels;

namespace WebParking.Controllers
{
    [Controller]
    [Route("CarCategories")]
    [Authorize(Roles = "admin")]
    //[Authorize] // только авторизованные admin
    public class CarCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var carCategories = _context.CarCategories.ToList();

            return View(carCategories);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(CarCategoriesCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var tempCarCategory = new CarCategory
                {
                    Name = form.Name,
                    Notes = form.Notes,
                    //Responsible = User.Identity.Name
                };

                _context.CarCategories.Add(tempCarCategory);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
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
            var carCategory = _context.CarCategories.FirstOrDefault(x => x.Id == Id);
            if (carCategory == null)
            {
                return NotFound("Не найдена категория с таким идентификатором!");
            }

            _context.CarCategories.Remove(carCategory);
            _context.SaveChanges();

            return NoContent();
        }
    }
}