using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DataLayer
{
    public class DalMessage : DalBase<Message, ChatApplicationContext>
    {
        ChatApplicationContext chatAppContext;
        public DalMessage()
        {
            chatAppContext = new ChatApplicationContext();
        }
        public int SendMessage(Message message)
        {
            chatAppContext.Add(message);
            return chatAppContext.SaveChanges();
        }
        public List<Message> GetGroupMessage(DateTime AddedDate, int groupId)
        {
            return chatAppContext.Messages.Where(x => x.GroupId == groupId && x.SendDate > AddedDate).ToList();

        }
        public List<Message> GetPrivateMessage(int senderId, int receiverId)
        {
            return chatAppContext.Messages.Where(x => x.ReceiverId == receiverId && x.SenderId == senderId).ToList();

        }
        public Message? GetByID(int id)
        {
            return chatAppContext.Messages.ToHashSet<Message>().FirstOrDefault(x => x.MessageId == id);
        }
        public bool Any(int? MessageID = null)
        {
            return chatAppContext
                .Messages
                .Any(x =>
                MessageID.HasValue && x.MessageId == MessageID);

        }
    }
}
