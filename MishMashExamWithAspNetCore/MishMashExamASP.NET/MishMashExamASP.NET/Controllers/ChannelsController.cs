using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MishMashExamASP.NET.Data.Models;
using MishMashExamASP.NET.Models;
using MishMashExamASP.NET.Services.Channels;

namespace MishMashExamASP.NET.Controllers
{
    public class ChannelsController : Controller
    {
        private readonly IChannelServices channelServices;

        public ChannelsController(IChannelServices channelServices)
        {
            this.channelServices = channelServices;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var inputModel = new CreateChannelInputModel()
            {
                ChannelTypes = new string[] {"Game", "Motivation", "Lessons", "Radio", "Other"}
            };

            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult CreateChannel(CreateChannelInputModel inputModel)
        {
            this.channelServices.CreateChannel(inputModel);
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult FollowChannel(string channelId)
        {
            this.channelServices.FollowChannel(this.User, channelId);
            return this.Json(channelId);
        }

        [HttpPost]
        public IActionResult UnfollowChannel(string channelId)
        {
            this.channelServices.UnfollowChannel(this.User, channelId);
            return this.Json(channelId);
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.channelServices.GetChannelDetailsModel(id);
            return this.View(viewModel);
        }

        public IActionResult MyChannels()
        {
            var model = this.channelServices.GetFollowingChannels(this.User);
            return this.View(model);
        }
    }
}