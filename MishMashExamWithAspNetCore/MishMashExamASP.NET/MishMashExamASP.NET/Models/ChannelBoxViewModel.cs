using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishMashExamASP.NET.Models
{
    public class ChannelBoxViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Followers { get; set; }

        public string Tags { get; set; }

        public string Description { get; set; }
    }
}
