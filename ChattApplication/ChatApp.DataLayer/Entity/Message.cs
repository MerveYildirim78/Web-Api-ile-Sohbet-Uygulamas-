using System;
using System.Collections.Generic;

namespace ChatApp.DataLayer.Entity
{
    public partial class Message
    {
        public Message()
        {
            Complains = new HashSet<Complain>();
        }

        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public int? GroupId { get; set; }
        public string MessageContent { get; set; } = null!;
        public DateTime SendDate { get; set; }
        public DateTime? ReadDate { get; set; }

        public virtual Group? Group { get; set; }
        public virtual User? Receiver { get; set; }
        public virtual User Sender { get; set; } = null!;
        public virtual ICollection<Complain> Complains { get; set; }
    }
}
