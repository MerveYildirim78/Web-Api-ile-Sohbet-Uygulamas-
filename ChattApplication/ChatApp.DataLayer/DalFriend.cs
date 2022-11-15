using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DataLayer
{
    public class DalFriend : DalBase<Friend,ChatApplicationContext>
    {
        ChatApplicationContext chatAppContext;
        public DalFriend()
        {
            chatAppContext = new ChatApplicationContext();
        }
        public List<Friend> GetList(int userID)
        {
            return chatAppContext
                .Friends.Where(x => x.RequestedUserId == userID).ToList();
        }
        public List<Friend> GetListAll()
        {
            return chatAppContext.Friends.ToList();
        }
        public bool Any(int? FriendIdExpect = null ,int? RequesterID = null, int? RequestedID = null)
        {
            return chatAppContext
                .Friends
                .Any(x =>
                (FriendIdExpect.HasValue && x.FriendId == FriendIdExpect) ||
                ((RequesterID.HasValue && x.RequesterUserId == RequesterID) &&
                (RequestedID.HasValue &&  x.RequestedUserId == RequestedID)));
        }
    }
}
