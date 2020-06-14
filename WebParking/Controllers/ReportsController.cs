using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            var pageVm = new MoneyReportViewModel();

            return View(pageVm);
        }

        [HttpPost("MoneyPost")]
        public IActionResult MoneyPost(MoneyReportViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Money", form);
            }

            var clients = _context.Clients
                .Include(x => x.CheckInOuts)
                .Where(x => x.CheckInOuts.All(y => y.DateCheckOut > form.Start && y.DateCheckOut < form.Finish))
                .ToList();

            var pageVm = new MoneyReportViewModel();

            var dataByClient = clients.Select(client => new MoneyReportItemViewModel
            {
                ClientFullName = client.FullName,
                ClientDocument = client.Document,
                Sum = client.CheckInOuts.Sum(y => y.Sum),
                Hours = client.CheckInOuts.Sum(y => y.TotalHours),
            }).ToList();

            pageVm.Item = dataByClient;
            pageVm.Start = form.Start;
            pageVm.Finish = form.Finish;

            //if (!ModelState.IsValid)
            //{
            //    return View("Money", form);
            //}

            return View("Money", pageVm);
        }
    }
}