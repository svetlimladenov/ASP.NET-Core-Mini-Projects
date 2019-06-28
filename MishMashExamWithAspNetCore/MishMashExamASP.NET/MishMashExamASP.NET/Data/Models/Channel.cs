using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishMashExamASP.NET.Data.Models
{
    public class Channel
    {
        public Channel()
        {
            this.Followers = new HashSet<UserChannel>();
            this.ChannelTags = new HashSet<ChannelTag>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType Type { get; set; }

        public virtual ICollection<ChannelTag> ChannelTags { get; set; }

        public virtual ICollection<UserChannel> Followers { get; set; }
    }
}
