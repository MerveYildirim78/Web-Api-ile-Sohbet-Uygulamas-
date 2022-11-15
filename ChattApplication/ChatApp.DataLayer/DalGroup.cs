using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DataLayer
{
    public class DalGroup : DalBase<Group, ChatApplicationContext>
    {
        ChatApplicationContext chatAppContext;
        public DalGroup()
        {
            chatAppContext = new ChatApplicationContext();
        }

        public Group? GetList(int groupId)
        {
            return chatAppContext.Groups.ToHashSet<Group>().FirstOrDefault(x => x.GroupId == groupId);
        }
        public bool Any(int? CreaterIdExpect = null, int? GroupID=null)
        {
            return chatAppContext
                .Groups
                .Any(x =>
                (GroupID.HasValue && x.GroupId == GroupID) ||
                (CreaterIdExpect.HasValue && x.CreaterUserId == CreaterIdExpect) 
                ); 

        }
    }
}
