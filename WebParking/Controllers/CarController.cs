using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebParking.Data;
using WebParking.Domain.Models;
using WebParking.ViewModels;

namespace WebParking.Controllers
{
    [Controller]
    [Route("Car")]
    [Authorize]
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var car = _context.Cars.Include(x => x.Category).Include(x => x.Client).Include(x => x.Responsible).ToList();

            return View(car);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            var Clients = _context.Clients.ToList();
            ViewBag.Clients = new SelectList(Clients, "Id", "FullName");

            var Categories = _context.CarCategories.ToList();
            ViewBag.Categories = new SelectList(Categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(CarCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var tempCar = new Car
                {
                    ClientId = form.ClientId,
                    Mark = form.Mark,
                    CategoryId = form.CategoryId,
                    StateNumber = form.StateNumber,
                    Color = form.Color,
                    Condition = form.Condition,
                    Notes = form.Notes,
                    ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
                };

                _context.Cars.Add(tempCar);
                _context.SaveChanges();

            }
            catch (Exception)
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
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound("Не найдено транспортное средство с таким идентификатором!");
            }
            var Clients = _context.Clients.ToList();
            ViewBag.Clients = new SelectList(Clients, "Id", "FullName");

            var Categories = _context.CarCategories.ToList();
            ViewBag.Categories = new SelectList(Categories, "Id", "Name");


            CarEditViewModel carEditViewModel = new CarEditViewModel();
            carEditViewModel.ClientId = car.ClientId;
            carEditViewModel.Mark = car.Mark;
            carEditViewModel.CategoryId = car.CategoryId;
            carEditViewModel.StateNumber = car.StateNumber;
            carEditViewModel.Color = car.Color;
            carEditViewModel.Condition = car.Condition;
            carEditViewModel.Notes = car.Notes;
            carEditViewModel.ResponsibleId = car.ResponsibleId;
            carEditViewModel.Id = car.Id;

            return View(carEditViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(CarEditViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", form);
            }

            var car = _context.Cars.FirstOrDefault(x => x.Id == form.Id);
            if (car == null)
            {
                return NotFound("Не найдено транспортное средство с таким идентификатором!");
            }

            try
            {
                car.ClientId = form.ClientId;
                car.Mark = form.Mark;
                car.CategoryId = form.CategoryId;
                car.StateNumber = form.StateNumber;
                car.Color = form.Color;
                car.Condition = form.Condition;
                car.Notes = form.Notes;
                car.ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

                _context.Cars.Update(car);
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }

            return RedirectToAction(nameof(List));
        }

        [HttpPost("Delete")]
        public IActionResult Delete(long Id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == Id);
            if (car == null)
            {
                return NotFound("Не найден автомобиль с таким идентификатором!");
            }

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return NoContent();
        }
    }
}