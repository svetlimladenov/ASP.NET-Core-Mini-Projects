﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class TrashController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
