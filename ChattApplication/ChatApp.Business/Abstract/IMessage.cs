using ChatApp.Common;
using ChatApp.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Business.Abstract
{
    public interface IMessage
    {
        public BCResponse SendMessage(MessageDTO dto);
        public BCResponse GetGroupMessage(int senderId, int groupId);
        public BCResponse GetPrivateMessage(int senderId, int receiverId);

    }
}
