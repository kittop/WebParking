﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    //[Authorize] // только авторизованные vse
    public class CheckInOutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckInOutController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult List()
        //{
        //    var car = _context.Cars.ToList();

        //    return View(car);
        //}

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.CheckTypes = new List<SelectListItem> { 
                new SelectListItem { Text = "Аренда", Value = "0" }, 
                new SelectListItem { Text = "Закрытие аренды", Value = "1" } 
            };

            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(CarCreateViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            return Ok(form);
        }

        //[HttpGet("Edit/{id}")]
        //public IActionResult Edit([FromRoute] long id)
        //{
        //    var car = _context.Cars.FirstOrDefault(x => x.Id == id);
        //    if (car == null)
        //    {
        //        return NotFound("Не найден автомобиль с таким идентификатором!");
        //    }

        //    CarEditViewModel carEditViewModel = new CarEditViewModel();
        //    carEditViewModel.Mark = car.Mark;
        //    carEditViewModel.SatetNumber = car.StatetNumber;
        //    carEditViewModel.Color = car.Color;
        //    carEditViewModel.Condition = car.Condition;
        //    carEditViewModel.Notes = car.Notes;
        //    carEditViewModel.Id = car.Id;

        //    return View(carEditViewModel);
        //}

        //[HttpPost("Edit")]
        //public IActionResult EditPost(CarEditViewModel form)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Edit", form);
        //    }

        //    var car = _context.Cars.FirstOrDefault(x => x.Id == form.Id);
        //    if (car == null)
        //    {
        //        return NotFound("Не найден автомобиль с таким идентификатором!");
        //    }

        //    try
        //    {
        //        car.Mark = form.Mark;
        //        car.StatetNumber = form.SatetNumber;
        //        car.Color = form.Color;
        //        car.Condition = form.Condition;
        //        car.Notes = form.Notes;
        //        car.Notes = form.Notes;

        //        _context.Cars.Update(car);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception exception)
        //    {

        //    }

        //    return RedirectToAction(nameof(List));
        //}

        //[HttpPost("Delete")]
        //public IActionResult Delete(long Id)
        //{
        //    var car = _context.Cars.FirstOrDefault(x => x.Id == Id);
        //    if (car == null)
        //    {
        //        return NotFound("Не найден автомобиль с таким идентификатором!");
        //    }

        //    _context.Cars.Remove(car);
        //    _context.SaveChanges();

        //    return NoContent();
        //}
    }
}