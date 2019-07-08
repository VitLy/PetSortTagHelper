using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetSortTagHelper.Data.Interfaces;
using PetSortTagHelper.Models;

namespace PetSortTagHelper.Controllers
{
    public class CatPageController : Controller
    {
        private readonly ICatRepository repository;

        public CatPageController(ICatRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult List()
        {
            return View(repository.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Cat cat)
        {
            repository.Add(cat);
            return View("List", repository.GetAll());
        }
    }
}