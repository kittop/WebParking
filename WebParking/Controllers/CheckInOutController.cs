using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebParking.Data;
using WebParking.Domain.Models;
using WebParking.ViewModels;

namespace WebParking.Controllers
{
    [Controller]
    [Route("Check")]
    [Authorize]
    public class CheckInOutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckInOutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public static Dictionary<CheckType, string> CheckTypesDesc = new Dictionary<CheckType, string> {
            { CheckType.CheckIn, "Открытие аренды" }, { CheckType.CheckOut, "Закрытие аренды"}
        };

        [HttpGet]
        public IActionResult List()
        {
            var checkInOut = _context.CheckInOuts.Include(x => x.Car).Include(x => x.Client).Include(x => x.Responsible).Include(x => x.Tariff).ToList();

            return View(checkInOut);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            var checkTypes = from CheckType d in Enum.GetValues(typeof(CheckType))
                           select new { Id = (int)d, Name = CheckTypesDesc[d] };
            ViewBag.CheckTypes = new SelectList(checkTypes, "Id", "Name");
           
            var Clients = _context.Clients.ToList();
            ViewBag.Clients = new SelectList(Clients, "Id", "FullName");

            var Cars = _context.Cars.ToList();
            ViewBag.Cars = new SelectList(Cars, "Id", "Mark");

            var Tariffies = _context.Tariffies.ToList();
            ViewBag.Tariffies = new SelectList(Tariffies, "Id", "Name");

            var ParkingPlaces = _context.ParkingPlaces.ToList();
            ViewBag.ParkingPlaces = new SelectList(ParkingPlaces, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(CheckInOutCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var CheckList = new CheckInOut
                {
                    CheckType = form.CheckType,
                    ClientId = form.ClientId,
                    CarId = form.CarId,
                    DateCheckIn = form.DateCheckIn,
                    DateCheckOut = form.DateCheckOut,
                    ParkingPlaceId = form.ParkingPlaceId,
                    TariffId = form.TariffId,
                    Sum = form.Sum,
                    TotalHours = form.TotalHours,
                    Notes = form.Notes,
                    ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
                };

                _context.CheckInOuts.Add(CheckList);
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
            var CheckList = _context.CheckInOuts.FirstOrDefault(x => x.Id == id);
            if (CheckList == null)
            {
                return NotFound("Не найдено зарегистрированное событие!");
            }

            var checkTypes = from CheckType d in Enum.GetValues(typeof(CheckType))
                             select new { Id = (int)d, Name = CheckTypesDesc[d] };
            ViewBag.CheckTypes = new SelectList(checkTypes, "Id", "Name");

            var Clients = _context.Clients.ToList();
            ViewBag.Clients = new SelectList(Clients, "Id", "FullName");

            var Cars = _context.Cars.ToList();
            ViewBag.Cars = new SelectList(Cars, "Id", "Mark");

            var Tariffies = _context.Tariffies.ToList();
            ViewBag.Tariffies = new SelectList(Tariffies, "Id", "Name");

            var ParkingPlaces = _context.ParkingPlaces.ToList();
            ViewBag.ParkingPlaces = new SelectList(ParkingPlaces, "Id", "Name");


            CheckInOutEditViewModel CheckEditViewModel = new CheckInOutEditViewModel
            {
                CheckType = CheckList.CheckType,
                ClientId = CheckList.ClientId,
                CarId = CheckList.CarId,
                DateCheckIn = CheckList.DateCheckIn,
                DateCheckOut = CheckList.DateCheckOut,
                ParkingPlaceId = CheckList.ParkingPlaceId,
                TariffId = CheckList.TariffId,
                Sum = CheckList.Sum,
                TotalHours = CheckList.TotalHours,
                Notes = CheckList.Notes,
                ResponsibleId = CheckList.ResponsibleId
            };

            return View(CheckEditViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(CheckInOutEditViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", form);
            }

            var CheckList = _context.CheckInOuts.FirstOrDefault(x => x.Id == form.Id);
            if (CheckList == null)
            {
                return NotFound("Не найдено зарегистрированное событие!");
            }

            try
            {
                CheckList.CheckType = form.CheckType;
                CheckList.ClientId = CheckList.ClientId;
                CheckList.CarId = CheckList.CarId;
                CheckList.DateCheckIn = CheckList.DateCheckIn;
                CheckList.DateCheckOut = CheckList.DateCheckOut;
                CheckList.ParkingPlaceId = CheckList.ParkingPlaceId;
                CheckList.TariffId = CheckList.TariffId;
                CheckList.Sum = CheckList.Sum;
                CheckList.TotalHours = CheckList.TotalHours;
                CheckList.Notes = CheckList.Notes;
                CheckList.ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

                _context.CheckInOuts.Update(CheckList);
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
            var CheckList = _context.CheckInOuts.FirstOrDefault(x => x.Id == Id);
            if (CheckList == null)
            {
                return NotFound("Не найдено зарегистрированное событие!");
            }

            _context.CheckInOuts.Remove(CheckList);
            _context.SaveChanges();

            return NoContent();
        }
    }
}