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
            var checkInOut = _context.CheckInOuts
                .Include(x => x.Car)
                .Include(x => x.ParkingPlace)
                .Include(x => x.Client)
                .Include(x => x.Responsible)
                .Include(x => x.Tariff).ToList();

            return View(checkInOut);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            FillViewBag();

            return View();
        }

        private void FillViewBag()
        {
            var checkTypes = from CheckType d in Enum.GetValues(typeof(CheckType))
                             select new { Id = (int)d, Name = CheckTypesDesc[d] };
            ViewBag.CheckTypes = new SelectList(checkTypes, "Id", "Name");

            var OpenCheckList = _context.CheckInOuts.Where(x => x.CheckType == CheckType.CheckIn).ToList();

            var Clients = _context.Clients.ToList();
            ViewBag.Clients = new SelectList(Clients, "Id", "FullName");

            var Cars = _context.Cars.ToList();
            ViewBag.Cars = new SelectList(Cars, "Id", "Mark");

            var Tariffies = _context.Tariffies.ToList();
            ViewBag.Tariffies = new SelectList(Tariffies, "Id", "Name");

            var ParkingPlaces = _context.ParkingPlaces.ToList();
            ViewBag.ParkingPlaces = new SelectList(ParkingPlaces, "Id", "Name");
        }

        [HttpPost]
        public IActionResult CreatePost(CheckInOutCreateViewModel form)
        {
            FillViewBag();

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
                    DateCheckOut = form.DateCheckOut.GetValueOrDefault(),
                    ParkingPlaceId = form.ParkingPlaceId,
                    TariffId = form.TariffId,
                    Notes = form.Notes,
                    ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
                };


                _context.CheckInOuts.Add(CheckList);
                
                var place = _context.ParkingPlaces.Where(x => x.Id == form.ParkingPlaceId).First();
                place.Free = false;
                _context.ParkingPlaces.Update(place);
               
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

            FillViewBag();

            CheckInOutEditViewModel CheckEditViewModel = new CheckInOutEditViewModel
            {
                Id = CheckList.Id,
                CheckType = CheckList.CheckType,
                ClientId = CheckList.ClientId,
                CarId = CheckList.CarId,
                DateCheckIn = CheckList.DateCheckIn,
                DateCheckOut = CheckList.DateCheckOut,
                ParkingPlaceId = CheckList.ParkingPlaceId,
                TariffId = CheckList.TariffId,
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

            var checkList = _context.CheckInOuts.FirstOrDefault(x => x.Id == form.Id);
            if (checkList == null)
            {
                return NotFound("Не найдено зарегистрированное событие!");
            }

            FillViewBag();

            try
            {
                checkList.CheckType = form.CheckType;
                //CheckList.ClientId = form.ClientId;
                //CheckList.CarId = form.CarId;
                checkList.DateCheckIn = form.DateCheckIn;
                checkList.DateCheckOut = form.DateCheckOut;
                checkList.ParkingPlaceId = form.ParkingPlaceId;
                checkList.TariffId = form.TariffId;
                checkList.Notes = form.Notes;
                checkList.ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

                _context.CheckInOuts.Update(checkList);
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }

            return RedirectToAction(nameof(List));
        }

        [HttpGet("Close/{id}")]
        public IActionResult Close([FromRoute] long id)
        {
            var CheckList = _context.CheckInOuts.FirstOrDefault(x => x.Id == id);
            if (CheckList == null)
            {
                return NotFound("Не найдено зарегистрированное событие!");
            }

            FillViewBag();

            CheckInOutCloseViewModel CheckCloseViewModel = new CheckInOutCloseViewModel
            {
                CheckType = CheckType.CheckOut,
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

            return View(CheckCloseViewModel);
        }

        [HttpPost("Close")]
        public IActionResult ClosePost(CheckInOutCloseViewModel form)
        {
            FillViewBag();

            if (!ModelState.IsValid)
            {
                return View("Close", form);
            }

            var check = _context.CheckInOuts
                .Include(x => x.ParkingPlace)
                .FirstOrDefault(x => x.Id == form.Id);
            if (check == null)
            {
                return NotFound("Не найдено зарегистрированное событие!");
            }

            if (check.CheckType == CheckType.CheckOut)
            {
                return BadRequest();
            }

            try
            {
                check.CheckType = CheckType.CheckOut;
                check.DateCheckIn = form.DateCheckIn;
                check.DateCheckOut = form.DateCheckOut.Value;

                var difference = check.DateCheckOut - check.DateCheckIn;
                var tariff = _context.Tariffies.First(x => x.Id == check.TariffId);

                if (tariff.AccrualType == AccrualType.Hourly)
                {
                    var hours = difference.TotalHours;
                    var sum = hours * tariff.Price;

                    check.Sum = sum;
                    check.TotalHours = hours;
                }
                else
                {
                    var hours = difference.TotalHours / 24;
                    var sum = hours * tariff.Price;

                    check.Sum = sum;
                    check.TotalHours = hours;
                }

                check.Notes = form.Notes;
                check.ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

                
                _context.CheckInOuts.Update(check);

                var place = check.ParkingPlace;
                place.Free = true;
                _context.ParkingPlaces.Update(place);

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
            var CheckList = _context.CheckInOuts.FirstOrDefault(x => x.Id == Id);
            if (CheckList == null)
            {
                return NotFound("Не найдено зарегистрированное событие!");
            }

            _context.CheckInOuts.Remove(CheckList);

            if (CheckList.CheckType == CheckType.CheckIn)
            {
                var place = _context.ParkingPlaces.Where(x => x.Id == CheckList.ParkingPlaceId).First();
                place.Free = false;
                _context.ParkingPlaces.Update(place);
            }

            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        [Route("GetTypeTariffJSON")]
        public IActionResult GetTypeTariff(long id)
        {
            var TypeTariff = _context.Tariffies.FirstOrDefault(x => x.Id == id);

            if (TypeTariff == null)
            { 
                return NotFound(nameof(CheckInOut));
            }
            
            return Ok(new { TypeTariff.AccrualType, TypeTariff.Price });
        }

    }
}