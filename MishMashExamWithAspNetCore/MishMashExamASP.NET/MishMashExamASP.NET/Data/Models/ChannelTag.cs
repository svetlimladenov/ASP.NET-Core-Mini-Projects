using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishMashExamASP.NET.Data.Models
{
    public class ChannelTag
    {
        public string ChannelId { get; set; }

        public virtual Channel Channel { get; set; }

        public string TagId { get; set; }

        public virtual Tag Tag { get; set; }    
    }
}
