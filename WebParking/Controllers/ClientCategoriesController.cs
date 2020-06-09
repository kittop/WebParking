using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WebParking.Data;
using WebParking.Domain.Models;
using WebParking.ViewModels;

namespace WebParking.Controllers
{
    [Controller]
    [Route("ClientCategories")]
    [Authorize(Roles = "admin")]
    public class ClientCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var clientCategories = _context.ClientCategories.Include(x => x.Responsible).ToList();
            return View(clientCategories);
        }

        [HttpGet("{id}")]
        public IActionResult Detail(long id)
        {
            var clientCategories = _context.ClientCategories.Include(x => x.Clients).FirstOrDefault(x => x.Id == id);

            return View(clientCategories);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        //public bool CheckClaim(System.Security.Claims.Claim claim)
        //{
        //    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
        //        return true;
        //    else
        //        return false;
        //}

        //public bool CheckClaim2(System.Security.Claims.Claim claim)
        //{
        //    return claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        //}

        //public static bool CheckClaim3(Claim claim) => 
        //    claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

        //static Func<Claim, bool> CC4 = (x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"; 
        //static Func<Claim, bool> CC5 = CC4;

        [HttpPost]
        public IActionResult CreatePost(ClientCategoriesCreateViewModel form)
        {

            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            try
            {
                var tempClientCategory = new ClientCategory
                {
                    Name = form.Name,
                    Notes = form.Notes,
                    ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
                };

                _context.ClientCategories.Add(tempClientCategory);
                _context.SaveChanges();

            }
            catch (Exception exception)
            {
                throw;
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
            var clientCategory = _context.ClientCategories.FirstOrDefault(x => x.Id == id);
            if (clientCategory == null)
            {
                return NotFound("Не найдена категория с таким идентификатором!");
            }

            ClientCategoriesEditViewModel clientCategoriesEditViewModel = new ClientCategoriesEditViewModel();
            clientCategoriesEditViewModel.Id = clientCategory.Id;
            clientCategoriesEditViewModel.Name = clientCategory.Name;
            clientCategoriesEditViewModel.Notes = clientCategory.Notes;
            clientCategoriesEditViewModel.ResponsibleId = clientCategory.ResponsibleId;
            return View(clientCategoriesEditViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult EditPost(ClientCategoriesEditViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", form);
            }

            var clientCategories = _context.ClientCategories.FirstOrDefault(x => x.Id == form.Id);
            if (clientCategories == null)
            {
                return NotFound("Не найдена категория с таким идентификатором!");
            }

            try
            {
                clientCategories.Name = form.Name;
                clientCategories.Notes = form.Notes;
                clientCategories.ResponsibleId = User.Claims.Single((x) => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                _context.ClientCategories.Update(clientCategories);
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
            var clientCategory = _context.ClientCategories.FirstOrDefault(x => x.Id == Id);
            if (clientCategory == null)
            {
                return NotFound("Не найдена категория с таким идентификатором!");
            }

            _context.ClientCategories.Remove(clientCategory);
            _context.SaveChanges();

            return NoContent();
        }
    }
}