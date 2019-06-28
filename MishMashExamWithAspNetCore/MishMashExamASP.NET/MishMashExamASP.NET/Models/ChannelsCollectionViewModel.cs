using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishMashExamASP.NET.Models
{
    public class ChannelsCollectionViewModel
    {
        public ICollection<ChannelBoxViewModel> FollowedChannels { get; set; }

        public ICollection<ChannelBoxViewModel> SuggestedChannels { get; set; }

        public ICollection<ChannelBoxViewModel> OtherChannels { get; set; }
    }
}
