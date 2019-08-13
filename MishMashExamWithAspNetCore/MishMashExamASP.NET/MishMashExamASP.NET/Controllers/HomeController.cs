using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MishMashExamASP.NET.Filters;
using MishMashExamASP.NET.Models;
using MishMashExamASP.NET.Services.Channels;

namespace MishMashExamASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IChannelServices channelServices;

        public HomeController(IConfiguration configuration, IChannelServices channelServices)
        {
            this.configuration = configuration;
            this.channelServices = channelServices;
        }
        public IActionResult Index()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.View("IndexLoggedOut");
            }

            var viewModel = channelServices.GetHomePageChannels(this.User);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
