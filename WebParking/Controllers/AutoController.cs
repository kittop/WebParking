using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebParking.Data;
using WebParking.Domain.Models;
using WebParking.ViewModels;

namespace WebParking.Controllers
{
    [Controller]
    [Route("Auto")]
    //[Authorize] // только авторизованные vse
    public class AutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var auto = _context.Auto.ToList();

            return View(auto);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(AutoCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var tempAuto = new Auto
                {
                    Mark = form.Mark,
                    SatetNumber = form.SatetNumber,
                    Color = form.Color,
                    Condition = form.Condition,
                    Notes = form.Notes,
                };

                _context.Auto.Add(tempAuto);
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
            var auto = _context.Auto.FirstOrDefault(x => x.Id == id);
            if (auto == null)
            {
                return NotFound("Не найден автомобиль с таким идентификатором!");
            }

            AutoEditViewModel autoEditViewModel = new AutoEditViewModel();
            autoEditViewModel.Mark = auto.Mark;
            autoEditViewModel.SatetNumber = auto.SatetNumber;
            autoEditViewModel.Color = auto.Color;
            autoEditViewModel.Condition = auto.Condition;
            autoEditViewModel.Notes = auto.Notes;
            autoEditViewModel.Id = auto.Id;

            return View(autoEditViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(AutoEditViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", form);
            }

            var auto = _context.Auto.FirstOrDefault(x => x.Id == form.Id);
            if (auto == null)
            {
                return NotFound("Не найден автомобиль с таким идентификатором!");
            }

            try
            {
                auto.Mark = form.Mark;
                auto.SatetNumber = form.SatetNumber;
                auto.Color = form.Color;
                auto.Condition = form.Condition;
                auto.Notes = form.Notes;
                auto.Notes = form.Notes;

                _context.Auto.Update(auto);
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
            var auto = _context.Auto.FirstOrDefault(x => x.Id == Id);
            if (auto == null)
            {
                return NotFound("Не найден автомобиль с таким идентификатором!");
            }

            _context.Auto.Remove(auto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}