using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MishMashExamASP.NET.Services.Users;

namespace MishMashExamASP.NET.ViewComponents
{
    public class LatestUserViewComponent : ViewComponent
    {
        private readonly IUserServices userServices;

        public LatestUserViewComponent(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        public IViewComponentResult Invoke(string text = "Latest User:")
        {
            var model = new LatestUserViewComponentViewModel
            {
                Text = text,
                Username = this.userServices.LatestUsername()
            };
            return this.View(model);
        }
    }

    public class LatestUserViewComponentViewModel
    {
        public string Text { get; set; }
        public string Username { get; set; }
    }
}
