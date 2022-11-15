using System;
using System.Collections.Generic;

namespace ChatApp.DataLayer.Entity
{
    public partial class GroupMember
    {
        public int GroupMemberId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public int AddedUserId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsAdmin { get; set; }

        public virtual User AddedUser { get; set; } = null!;
        public virtual Group Group { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
