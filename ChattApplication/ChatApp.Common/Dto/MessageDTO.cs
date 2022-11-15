using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Common.Dto
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        [Required]
        public int SenderId { get; set; }
        public int? ReceiverId { get; set; } = null;
        public int? GroupId { get; set; } = null;
        [Required]
        public string MessageContent { get; set; }
        [Required]
        public DateTime SendDate { get; set; }= DateTime.Now;
        [Required]
        public DateTime? ReadDate { get; set; }
    }
}
