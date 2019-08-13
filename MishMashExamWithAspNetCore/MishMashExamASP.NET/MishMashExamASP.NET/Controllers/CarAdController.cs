    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;
    using MishMashExamASP.NET.Models.CarAd;

    namespace MishMashExamASP.NET.Controllers
{
    public class CarAdController : Controller
    {
        public CarAdController()
        {
            
        }
        public IActionResult Create()
        {
            //TODO: default values
            var model = new CreateInputModel()
            {
                LongDescription = "initial value"
            };
            return this.View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            return this.Json(inputModel);
        }
    }
}