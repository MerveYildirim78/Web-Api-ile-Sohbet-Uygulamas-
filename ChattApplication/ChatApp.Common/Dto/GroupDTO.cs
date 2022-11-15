using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Common.Dto
{
    public class GroupDTO
    {
        public int GroupId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? GroupProfilePhoto { get; set; }
        [Required]
        public int CreaterUserId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
