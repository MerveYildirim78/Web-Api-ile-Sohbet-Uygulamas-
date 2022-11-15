using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Common.Dto
{
    public class FriendDTO
    {
        public int FriendId { get; set; }
        [Required]
        public int RequesterUserId { get; set; }
        [Required]
        public int RequestedUserId { get; set; }
        [Required]
        public byte FriendStatusId { get; set; }
        [Required]
        public System.DateTime RequestedDate { get; set; }
    }
}
