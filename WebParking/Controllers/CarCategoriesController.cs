using Microsoft.AspNetCore.Authorization;
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
            var carCategories = _context.CarCategories.Include(x => x.Responsible).ToList();

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
                    ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
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

        [HttpGet("Edit/{id}")]
        public IActionResult Edit([FromRoute] long id)
        {
            var carCategory = _context.CarCategories.FirstOrDefault(x => x.Id == id);
            if (carCategory == null)
            {
                return NotFound("Не найдена категория с таким идентификатором!");
            }

            CarCategoriesEditViewModel carCategoriesEditViewModel = new CarCategoriesEditViewModel();
            carCategoriesEditViewModel.Id = carCategory.Id;
            carCategoriesEditViewModel.Name = carCategory.Name;
            carCategoriesEditViewModel.Notes = carCategory.Notes;

            return View(carCategoriesEditViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(CarCategoriesEditViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", form);
            }

            var carCategories = _context.CarCategories.FirstOrDefault(x => x.Id == form.Id);
            if (carCategories == null)
            {
                return NotFound("Не найдена категория с таким идентификатором!");
            }

            try
            {
                carCategories.Name = form.Name;
                carCategories.Notes = form.Notes;

                _context.CarCategories.Update(carCategories);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
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