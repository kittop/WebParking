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
    [Route("Tariffies")]
    [Authorize(Roles = "admin")] // только авторизованные - admin
    public class TariffiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public static Dictionary<AccrualType, string> AccrualTypesDesc = new Dictionary<AccrualType, string> {
            { AccrualType.Hourly, "Почасовой" }, { AccrualType.Daily, "Посуточный"}
        };

        public TariffiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var tariff = _context.Tariffies.Include(x => x.Responsible).ToList();
            
            return View(tariff);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            var accTypes = from AccrualType d in Enum.GetValues(typeof(AccrualType))
                           select new { Id = (int)d, Name = AccrualTypesDesc[d] };
            ViewBag.AccrualTypes = new SelectList(accTypes, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(TariffCreateViewModel form)
        {
            var accTypes = from AccrualType d in Enum.GetValues(typeof(AccrualType))
                           select new { Id = (int)d, Name = AccrualTypesDesc[d] };
            ViewBag.AccrualTypes = new SelectList(accTypes, "Id", "Name");

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
                    Notes = form.Notes,
                    AccrualType = form.AccrualType,
                    ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
                };

                _context.Tariffies.Add(tempTariff);
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
            var accTypes = from AccrualType d in Enum.GetValues(typeof(AccrualType))
                           select new { Id = (int)d, Name = AccrualTypesDesc[d] };
            ViewBag.AccrualTypes = new SelectList(accTypes, "Id", "Name");

            var tariff = _context.Tariffies.FirstOrDefault(x => x.Id == id);
            if (tariff == null)
            {
                return NotFound("Не найден тариф с таким идентификатором!");
            }

            TariffEditViewModel tariffEditViewModel = new TariffEditViewModel();
            tariffEditViewModel.Name = tariff.Name;
            tariffEditViewModel.Price = (double)tariff.Price;
            tariffEditViewModel.Notes = tariff.Notes;
            tariffEditViewModel.AccrualType = tariff.AccrualType;
            tariffEditViewModel.Id = tariff.Id;
            tariffEditViewModel.ResponsibleId = tariff.ResponsibleId;
            return View(tariffEditViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(TariffEditViewModel form)
        {
            var accTypes = from AccrualType d in Enum.GetValues(typeof(AccrualType))
                           select new { Id = (int)d, Name = AccrualTypesDesc[d] };
            ViewBag.AccrualTypes = new SelectList(accTypes, "Id", "Name");

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
                tariff.AccrualType = form.AccrualType;
                tariff.ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                _context.Tariffies.Update(tariff);
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