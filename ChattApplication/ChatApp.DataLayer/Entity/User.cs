using System;
using System.Collections.Generic;

namespace ChatApp.DataLayer.Entity
{
    public partial class User
    {
        public User()
        {
            ComplainComplainantUsers = new HashSet<Complain>();
            ComplainComplainedOfUsers = new HashSet<Complain>();
            GroupMemberAddedUsers = new HashSet<GroupMember>();
            GroupMemberUsers = new HashSet<GroupMember>();
            Groups = new HashSet<Group>();
            MessageReceivers = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Username { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ProfilePhoto { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual Friend FriendRequestedUser { get; set; } = null!;
        public virtual Friend FriendRequesterUser { get; set; } = null!;
        public virtual ICollection<Complain> ComplainComplainantUsers { get; set; }
        public virtual ICollection<Complain> ComplainComplainedOfUsers { get; set; }
        public virtual ICollection<GroupMember> GroupMemberAddedUsers { get; set; }
        public virtual ICollection<GroupMember> GroupMemberUsers { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Message> MessageReceivers { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
    }
}
