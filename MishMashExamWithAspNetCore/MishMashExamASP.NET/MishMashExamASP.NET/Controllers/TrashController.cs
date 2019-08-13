using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MishMashExamASP.NET.Filters;
using MishMashExamASP.NET.Models;
using MishMashExamASP.NET.Services;

namespace MishMashExamASP.NET.Controllers
{
    public class TrashInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int Age { get; set; }
    }

    //[TypeFilter(typeof(MyAuthorizeFilter), Arguments = new object[] {"aa"})]
    [ServiceFilter(typeof(MyAuthorizeFilter))] // with this way should register the filter in with services.addScoped or addTransient...
    public class TrashController : Controller
    {
        private readonly ICounterService counterService;

        public TrashController(ICounterService counterService)
        {
            this.counterService = counterService;
        }
        [AddHeader("X-Filter","FilterValue")]
        public IActionResult Index(TrashInputModel inputModel)
        {   
            return this.Json(inputModel);
        }
        [ValidateModelStateFilter]
        public IActionResult AcceptForm(FormInputModel inputModel)
        {
            return this.Content("OK");
        }

        public IActionResult ErrorView()
        {
            throw new ArgumentException("There is an exception");
            return this.Content("This is an error view");
        }
    }

}