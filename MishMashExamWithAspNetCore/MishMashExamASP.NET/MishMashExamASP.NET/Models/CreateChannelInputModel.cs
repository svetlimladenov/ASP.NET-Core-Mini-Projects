using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishMashExamASP.NET.Models
{
    public class CreateChannelInputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public IEnumerable<string> ChannelTypes { get; set; }
        public string SelectedChannelType { get; set; }
    }
}
