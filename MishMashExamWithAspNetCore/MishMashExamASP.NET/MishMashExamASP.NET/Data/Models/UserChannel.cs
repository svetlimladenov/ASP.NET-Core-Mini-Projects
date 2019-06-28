using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishMashExamASP.NET.Data.Models
{
    public class UserChannel
    {
        public string MishMashUserId { get; set; }

        public MishMashUser MishMashUser { get; set; }

        public string ChannelId { get; set; }

        public Channel Channel { get; set; }
    }
}
