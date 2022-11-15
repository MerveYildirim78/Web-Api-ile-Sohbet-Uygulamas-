using System;
using System.Collections.Generic;

namespace ChatApp.DataLayer.Entity
{
    public partial class ComplainStatus
    {
        public ComplainStatus()
        {
            Complains = new HashSet<Complain>();
        }

        public byte ComplainStatusId { get; set; }
        public string ComplainDescription { get; set; } = null!;

        public virtual ICollection<Complain> Complains { get; set; }
    }
}
