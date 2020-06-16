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
    [Route("ParkingPlace")]
    [Authorize]
    public class ParkingPlaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParkingPlaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var places = _context.ParkingPlaces.Include(x => x.Responsible).ToList();

            return View(places);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(ParkingPlaceCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var tempParkingPlace = new ParkingPlace
                {
                    Name = form.Name,
                    Free = form.Free,
                    Notes = form.Notes,
                    ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
                };

                _context.ParkingPlaces.Add(tempParkingPlace);
                _context.SaveChanges();

            }
            catch (Exception exception)
            {
                if (((Npgsql.PostgresException)exception.InnerException).ConstraintName == "IX_ParkingPlaces_Name")
                {
                    ModelState.AddModelError(nameof(ParkingPlaceCreateViewModel.Name), "Наименование не уникально. Некоторые записи созданы. См. справочник!");
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
            var parkingPlace = _context.ParkingPlaces.FirstOrDefault(x => x.Id == id);
            if (parkingPlace == null)
            {
                return NotFound("Не найдено парковочное место с таким идентификатором!");
            }

            ParkingPlaceEditViewModel parkingPlaceEditViewModel = new ParkingPlaceEditViewModel();
            parkingPlaceEditViewModel.Name = parkingPlace.Name;
            parkingPlaceEditViewModel.Free = parkingPlace.Free;
            parkingPlaceEditViewModel.ResponsibleId = parkingPlace.ResponsibleId;
            parkingPlaceEditViewModel.Notes = parkingPlace.Notes;
            parkingPlaceEditViewModel.Id = parkingPlace.Id;

            return View(parkingPlaceEditViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(ParkingPlaceEditViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", form);
            }

            var parkingPlace = _context.ParkingPlaces.FirstOrDefault(x => x.Id == form.Id);
            if (parkingPlace == null)
            {
                return NotFound("Не найдено парковочное место с таким идентификатором!");
            }

            try
            {
                parkingPlace.Name = form.Name;
                parkingPlace.Free = form.Free;
                parkingPlace.ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                parkingPlace.Notes = form.Notes;

                _context.ParkingPlaces.Update(parkingPlace);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                if (((Npgsql.PostgresException)exception.InnerException).ConstraintName == "IX_ParkingPlaces_Name")
                {
                    ModelState.AddModelError(nameof(ParkingPlaceEditViewModel.Name), "Наименование не уникально!");
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(List));
        }

        [HttpGet("Fill")]
        public IActionResult Fill()
        {
            return View();
        }

        [HttpPost("FillPost")]
        public IActionResult FillPost(ParkingPlaceFillViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Fill", form);
            }

            try
            {
                var Count = form.Count;
                var Start = (int)form.Start;



                for (int i = Start; i < Count + 1; i++)
                {
                    ParkingPlace parkingPlace = new ParkingPlace
                    {
                        Creation = DateTime.Now,
                        Free = true,
                        ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value,
                        Notes = "Сгенерировано автоматически",
                        Name = i.ToString(),
                    };
                    _context.ParkingPlaces.Add(parkingPlace);
                };
                

               _context.SaveChanges();

            }
            catch (Exception exception)
            {
                if (((Npgsql.PostgresException)exception.InnerException).ConstraintName == "IX_ParkingPlaces_Name")
                {
                    ModelState.AddModelError(nameof(ParkingPlaceEditViewModel.Name), "Наименование не уникально!");
                }
                else
                {
                    throw;
                }
            }

            if (!ModelState.IsValid)
            {
                return View("Fill", form);
            }

            return RedirectToAction(nameof(List));
        }

        [HttpPost("Delete")]
        public IActionResult Delete(long Id)
        {
            var parkingPlace = _context.ParkingPlaces.FirstOrDefault(x => x.Id == Id);
            if (parkingPlace == null)
            {
                return NotFound("Не найдено парковочное место с таким идентификатором!");
            }

            _context.ParkingPlaces.Remove(parkingPlace);
            _context.SaveChanges();

            return NoContent();
        }
    }
}