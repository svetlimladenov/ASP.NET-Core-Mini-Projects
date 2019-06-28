using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MishMashExamASP.NET.Data;
using MishMashExamASP.NET.Data.Models;
using MishMashExamASP.NET.Models;

namespace MishMashExamASP.NET.Services.Channels
{
    public class ChannelServices : IChannelServices
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<MishMashUser> userManager;

        public ChannelServices(ApplicationDbContext db, UserManager<MishMashUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public void CreateChannel(CreateChannelInputModel model)
        {
            if (!Enum.TryParse(model.SelectedChannelType, true, out ChannelType type))
            {
                throw new ArgumentException("Invalid Channel Type");
            }

            var channel = new Channel()
            {
                Name = model.Name,
                Description = model.Description,
                Type = type
            };



            if (!string.IsNullOrWhiteSpace(model.Tags))
            {
                var tags = model.Tags.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var tag in tags)
                {
                    var dbTag = this.db.Tags.FirstOrDefault(x => x.Name == tag.Trim());
                    if (dbTag == null)
                    {
                        dbTag = new Tag() { Name = tag.Trim() };
                        this.db.Tags.Add(dbTag);
                        this.db.SaveChanges();
                    }

                    channel.ChannelTags.Add(new ChannelTag()
                    {
                        TagId = dbTag.Id
                    });
                }

            }

            this.db.Channels.Add(channel);
            this.db.SaveChanges();
        }

        public ChannelsCollectionViewModel GetHomePageChannels(ClaimsPrincipal user)
        {
            var userId = this.userManager.GetUserId(user);
            var followedChannels = this.db.UserChannels
                .Where(x => x.MishMashUserId == userId)
                .Select(x => x.Channel)
                .Select(ch => new ChannelBoxViewModel()
                {
                    Id = ch.Id,
                    Name = ch.Name,
                    Type = ch.Type.ToString(),
                    Followers = ch.Followers.Count // check if works correct
                }).ToList();

            var notFollowedChannels = this.db.Channels.
                    Where(ch => ch.Followers.FirstOrDefault(x => x.MishMashUserId == userId) == null)
                    .Select(ch => new ChannelBoxViewModel()
                    {
                        Id = ch.Id,
                        Name = ch.Name,
                        Type = ch.Type.ToString(),
                        Followers = ch.Followers.Count
                    }).ToArray();

            var followedChannelsTags = this.db.Channels.Where(
                    x => x.Followers.Any(f => f.MishMashUserId == userId))
                .SelectMany(x => x.ChannelTags.Select(t => t.TagId)).ToList();

            var suggestedChannels = this.db.Channels.Where(
                x => !x.Followers.Any(f => f.MishMashUserId == userId) &&
                     x.ChannelTags.Any(t => followedChannelsTags.Contains(t.TagId)))
                .Select(ch => new ChannelBoxViewModel()
                {
                    Id = ch.Id,
                    Name = ch.Name,
                    Type = ch.Type.ToString(),
                    Followers = ch.Followers.Count
                }).ToArray();

            var model = new ChannelsCollectionViewModel();
            model.FollowedChannels = followedChannels;
            model.OtherChannels = notFollowedChannels;
            model.SuggestedChannels = suggestedChannels;

            return model;
        }

        public void FollowChannel(ClaimsPrincipal user, string channelId)
        {
            var userId = this.userManager.GetUserId(user);
            this.db.UserChannels.Add(new UserChannel()
            {
                MishMashUserId = userId,
                ChannelId = channelId
            });
            this.db.SaveChanges();
        }

        public void UnfollowChannel(ClaimsPrincipal user, string channelId)
        {
            var userId = this.userManager.GetUserId(user);
            var userFollow = this.db.UserChannels.FirstOrDefault(x => x.MishMashUserId == userId && x.ChannelId == channelId);
            if (userFollow == null)
            {
                throw new ArgumentException("Invalid channel");
            }

            this.db.UserChannels.Remove(userFollow);
            this.db.SaveChanges();
        }

        public ChannelBoxViewModel GetChannelDetailsModel(string id)
        {
            var channel = this.db.Channels.Include(x => x.Followers).Include(x => x.ChannelTags).ThenInclude(c => c.Tag).FirstOrDefault(x => x.Id == id);
            var viewModel = new ChannelBoxViewModel()
            {
                Name = channel.Name,
                Description = channel.Description,
                Followers = channel.Followers.Count,
                Id =  channel.Id,
                Type = channel.Type.ToString(),
                Tags = string.Join(", ", channel.ChannelTags.Select(x => x.Tag).Select(t => t.Name))
            };

            return viewModel;
        }

        public IEnumerable<ChannelBoxViewModel> GetFollowingChannels(ClaimsPrincipal user)
        {
            var userId = this.userManager.GetUserId(user);
            var followedChannels = this.db.UserChannels
                .Where(x => x.MishMashUserId == userId)
                .Select(x => x.Channel)
                .Select(ch => new ChannelBoxViewModel()
                {
                    Id = ch.Id,
                    Name = ch.Name,
                    Type = ch.Type.ToString(),
                    Followers = ch.Followers.Count
                }).ToList();

            return followedChannels;
        }
    }
}