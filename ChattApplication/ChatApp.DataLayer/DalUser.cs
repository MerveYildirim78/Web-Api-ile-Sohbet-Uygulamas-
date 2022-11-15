using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DataLayer
{
    public class DalUser :DalBase<User,ChatApplicationContext>
    {
        ChatApplicationContext chatAppContext;
        public DalUser()
        {
            chatAppContext = new ChatApplicationContext();
        }
        public List<User> GetUsers()
        {
            return chatAppContext.Users.ToList();
        }
        public User? GetByID(int id)
        {
            return chatAppContext.Users.ToHashSet<User>().FirstOrDefault(x => x.UserId==id);
        }
        public User? GetByUsername(string userName)
        {
            return chatAppContext.Users.ToHashSet<User>().FirstOrDefault(x => x.Username == userName);
        }
        public bool Any(int? UserIdExpect = null, string? email=null, string? UserName = null)
        {
            return chatAppContext
                .Users
                .Any(x =>
                (!UserIdExpect.HasValue || x.UserId == UserIdExpect) &&
                (string.IsNullOrEmpty(UserName) || x.Username==UserName)&&
                (string.IsNullOrEmpty(email) || x.Email == email));

        }
    }
}
