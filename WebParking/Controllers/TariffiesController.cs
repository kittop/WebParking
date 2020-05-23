using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebParking.Data;
using WebParking.Domain.Models;
using WebParking.ViewModels;


namespace WebParking.Controllers
{
    [Controller]
    [Route("Tariffies")]
    //[Authorize(Roles ="")] // только авторизованные
    public class TariffiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TariffiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var tariff = _context.Tariffies.ToList();

            return View(tariff);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(TariffCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var tempTariff = new Tariff
                {
                    Name = form.Name,
                    Price = form.Price,
                    Notes = form.Notes
                };

                _context.Tariffies.Add(tempTariff);
                _context.SaveChanges();

            }
            catch (Exception exception)
            {
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
            var tariff = _context.Tariffies.FirstOrDefault(x => x.Id == id);
            if (tariff == null)
            {
                return NotFound("Не найден тариф с таким идентификатором!");
            }

            TariffEditViewModel tariffEditViewModel = new TariffEditViewModel();
            tariffEditViewModel.Name = tariff.Name;
            tariffEditViewModel.Price = tariff.Price;
            tariffEditViewModel.Notes = tariff.Notes;
            tariffEditViewModel.Id = tariff.Id;

            return View(tariffEditViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(TariffEditViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", form);
            }

            var tariff = _context.Tariffies.FirstOrDefault(x => x.Id == form.Id);
            if (tariff == null)
            {
                return NotFound("Не найден тариф с таким идентификатором!");
            }

            try
            {
                tariff.Name = form.Name;
                tariff.Price = form.Price;
                tariff.Notes = form.Notes;

                _context.Tariffies.Update(tariff);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
            }

            return RedirectToAction(nameof(List));
        }

        [HttpPost("Delete")]
        public IActionResult Delete(long Id)
        {
            var tariff = _context.Tariffies.FirstOrDefault(x => x.Id == Id);
            if (tariff == null)
            {
                return NotFound("Не найден тариф с таким идентификатором!");
            }

            _context.Tariffies.Remove(tariff);
            _context.SaveChanges();

            return NoContent();
        }
    }
}