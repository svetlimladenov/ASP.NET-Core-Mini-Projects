using System.Linq;
using MishMashExamASP.NET.Data;

namespace MishMashExamASP.NET.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext db;

        public UserServices(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string LatestUsername()
        {
            return  this.db.Users.OrderByDescending(x => x.Email).Select(x => x.UserName).FirstOrDefault();
        }
    }
}