using ChatApp.Business.Abstract;
using ChatApp.Common;
using ChatApp.Common.Dto;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;

namespace ChatApp.Business.Concrete
{
    public class MessageManager : ManagerBase<MessageDTO>, IMessage
    {
        DalMessage _dalMessage;
        DalGroupMember _dalGroupMember;
        public MessageManager(DalMessage dalMessage,DalGroupMember dalGroupMember)
        {
            _dalMessage = dalMessage;
            _dalGroupMember = dalGroupMember;
        }

        public override BCResponse Update(MessageDTO dto)
        {
            throw new NotImplementedException();
        }
        public override BCResponse Add(MessageDTO dto)
        {
            throw new NotImplementedException();
        }

        public override BCResponse Delete(MessageDTO dto)
        {
            var isExist = _dalMessage.Any(MessageID: dto.MessageId);
            if (isExist)
            {
                var message = _dalMessage.GetByID(dto.MessageId);
                if (message != null && message.SenderId == dto.SenderId)
                {
                    var result = _dalMessage.Delete(message);
                    if (result > 0)
                    {
                        return new BCResponse() { Value = result };
                    }
                    return new BCResponse() { Errors = "Sistem hatası." };
                }
                return new BCResponse() { Errors = "Gönderici değilsiniz" };


            }

            return new BCResponse() { Errors = "Mesaj bulunamadı." };
        }

        public BCResponse GetGroupMessage(int receiverId, int groupId)
        {
            var groupMember= _dalGroupMember.GetByUserId(receiverId, groupId);
            if (groupMember != null)
            {
                var record = _dalMessage.GetGroupMessage(groupMember.AddedDate, groupId);
                if (record == null || record.Count == 0)
                {
                    return new BCResponse() { Errors = "Mesaj bulunamadı" };

                }
                return new BCResponse() { Value = record };
            }
            return new BCResponse() { Errors = "Grup üyesi değilsiniz mesajları göremezsiniz." };
        }

        public BCResponse GetPrivateMessage(int senderId, int receiverId)
        {
            var record = _dalMessage.GetPrivateMessage(senderId, receiverId);
            if (record == null || record.Count == 0)
            {
                return new BCResponse() { Errors = "Mesaj bulunamadı" };

            }
            return new BCResponse() { Value = record };
        }

        public BCResponse SendMessage(MessageDTO dto)
        {
            if (dto.SenderId == 0 && dto.GroupId == 0)
            {
                return new BCResponse() { Errors = "Alıcı Giriniz" };
            }
            Message entity = new Message();
            entity.MessageId = dto.MessageId;
            entity.SenderId = dto.SenderId;
            entity.ReceiverId = dto.ReceiverId;
            entity.GroupId = dto.GroupId;
            entity.MessageContent = dto.MessageContent;
            entity.SendDate = dto.SendDate;
            entity.ReadDate = dto.ReadDate;

            if (dto.ReceiverId == 0)
            {
                entity.ReceiverId = null;
                entity.GroupId = dto.GroupId;
                var result = _dalMessage.SendMessage(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors = "Sistem Hatası" };
            }
            if (dto.GroupId == 0)
            {
                entity.GroupId = null;
                entity.ReceiverId = dto.ReceiverId;
                var result = _dalMessage.SendMessage(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors = "Sistem Hatası" };
            }

            return new BCResponse() { Errors = "Eksik veri" };

        }

    }
}
