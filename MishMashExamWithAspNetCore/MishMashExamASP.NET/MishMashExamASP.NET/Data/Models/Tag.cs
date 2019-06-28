using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishMashExamASP.NET.Data.Models
{
    public class Tag
    {
        public Tag()
        {
            this.TagChannels = new HashSet<ChannelTag>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ChannelTag> TagChannels { get; set; }
    }
}
