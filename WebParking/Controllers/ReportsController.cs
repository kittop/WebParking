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
    [Route("Reports")]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("FreeParkingPlacesList")]
        public IActionResult FreeParkingPlacesList()
        {
            var FreeParkingPlace = _context.ParkingPlaces.Include(x => x.Responsible).Where((x) => x.Free == true).ToList();
            
            return View(FreeParkingPlace);
        }

        [HttpGet("Money")]
        public IActionResult Money()
        {
            var Clients = _context.Clients.ToList();
            ViewBag.Clients = new SelectList(Clients, "Id", "FullName");

            var check = _context.CheckInOuts
                .Include(x => x.Car)
                .Include(x => x.ParkingPlace)
                .Include(x => x.Client)
                .Include(x => x.Responsible)
                .Include(x => x.Tariff)
                //.Where(x => x.ClientId == form.ClientId)
                .ToList();

            return View(check);
        }

        //[HttpPost]
        //public IActionResult MoneyPost(MoneyReportViewModel form)
        //{
        //    var Clients = _context.Clients.ToList();
        //    ViewBag.Clients = new SelectList(Clients, "Id", "FullName");

        //    var check = _context.CheckInOuts
        //        .Include(x => x.Car)
        //        .Include(x => x.ParkingPlace)
        //        .Include(x => x.Client)
        //        .Include(x => x.Responsible)
        //        .Include(x => x.Tariff)
        //        .Where(x => x.ClientId == form.ClientId).ToList();

        //    return View(check);
        //}


    }
}