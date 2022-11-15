using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DataLayer
{
    public class DalGroupMember : DalBase<GroupMember, ChatApplicationContext>
    {
        ChatApplicationContext chatAppContext;
        public DalGroupMember()
        {
            chatAppContext = new ChatApplicationContext();
        }
        public List<GroupMember> GetAll(int groupID)
        {
            return chatAppContext.GroupMembers.Where(x => x.GroupId == groupID).ToList();
        }
        public bool Any(int? GroupIdExpect = null,int? GroupMemberExpect=null)
        {
            return chatAppContext
                .GroupMembers
                .Any(x =>
                (!GroupIdExpect.HasValue || x.GroupId == GroupIdExpect)&&
                (GroupMemberExpect.HasValue && x.AddedUserId == GroupMemberExpect)); 

        }
        public GroupMember? GetById(int id)
        {
            return chatAppContext.GroupMembers.ToHashSet<GroupMember>().FirstOrDefault(x => x.GroupMemberId == id);
        }
        public GroupMember? GetByUserId(int UserId,int groupId)
        {
            return chatAppContext.GroupMembers.ToHashSet<GroupMember>().FirstOrDefault(x => x.UserId == UserId && x.GroupId==groupId);
        }
    }
}
