using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MishMashExamASP.NET.Data.Models
{
    public class MishMashUser : IdentityUser
    {
        public MishMashUser()
        {
            this.UserChannels = new HashSet<UserChannel>();
        }

        public ICollection<UserChannel> UserChannels { get; set; }
    }
}
