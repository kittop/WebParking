using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebParking.Data;
using WebParking.Domain.Models;
using WebParking.ViewModels;

namespace WebParking.Controllers
{
    [Controller]
    [Route("ParkingPlace")]
    //[Authorize] // только авторизованные - admin
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
            var places = _context.ParkingPlaces.ToList();

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
                    //CategoryId = form.CategoryId,
                    Free = form.Free,
                    Notes = form.Notes
                };

                _context.ParkingPlaces.Add(tempParkingPlace);
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
            var parkingPlace = _context.ParkingPlaces.FirstOrDefault(x => x.Id == id);
            if (parkingPlace == null)
            {
                return NotFound("Не найдено парковочное место с таким идентификатором!");
            }

            ParkingPlaceEditViewModel parkingPlaceEditViewModel = new ParkingPlaceEditViewModel();
            parkingPlaceEditViewModel.Name = parkingPlaceEditViewModel.Name;
            parkingPlaceEditViewModel.Free = parkingPlaceEditViewModel.Free;
            parkingPlaceEditViewModel.Notes = parkingPlaceEditViewModel.Notes;
            parkingPlaceEditViewModel.Id = parkingPlaceEditViewModel.Id;

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
                //parkingPlace.CategoryId = form.Category.GetId()
                parkingPlace.Notes = form.Notes;

                _context.ParkingPlaces.Update(parkingPlace);
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