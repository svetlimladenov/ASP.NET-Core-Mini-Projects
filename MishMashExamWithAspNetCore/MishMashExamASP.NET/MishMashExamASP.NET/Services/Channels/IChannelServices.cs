using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MishMashExamASP.NET.Models;

namespace MishMashExamASP.NET.Services.Channels
{
    public interface IChannelServices
    {
        void CreateChannel(CreateChannelInputModel model);

        ChannelsCollectionViewModel GetHomePageChannels(ClaimsPrincipal user);

        void FollowChannel(ClaimsPrincipal user, string channelId);

        void UnfollowChannel(ClaimsPrincipal user, string channelId);

        ChannelBoxViewModel GetChannelDetailsModel(string id);

        IEnumerable<ChannelBoxViewModel> GetFollowingChannels(ClaimsPrincipal user);
    }
}
