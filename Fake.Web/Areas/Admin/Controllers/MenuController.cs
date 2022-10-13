﻿using Fake.DataAccess.Repository;
using Fake.DataAccess.Repository.IRepository;
using Fake.Models;
using Fake.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fake.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var product = _unitOfWork.Product.GetAll().ToList();
            return View(product);
        }


        // get action   
        public IActionResult Upsert(Guid? id)
        {
           var ifInDb = _unitOfWork.Product.GetFirstOrDefault(f => f.Id == id);

            return View(ifInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, DateTime dt)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model", "your model is no working ");
                return View();
            }
            Console.WriteLine(dt);
            Product pro = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == obj.Product.Id);
            return View(pro);
        }
    }
}
