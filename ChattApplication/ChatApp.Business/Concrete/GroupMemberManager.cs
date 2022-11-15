using ChatApp.Business.Abstract;
using ChatApp.Common;
using ChatApp.Common.Dto;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;

namespace ChatApp.Business.Concrete
{
    public class GroupMemberManager : ManagerBase<GroupMemberDTO>, IGroupMember
    {
        DalGroupMember _dalGroupMember;
        DalGroup dalGroup;
        public GroupMemberManager(DalGroupMember dalGroupMember, DalGroup dalGroup)
        {
            _dalGroupMember = dalGroupMember;
            this.dalGroup = dalGroup;
        }

        public override BCResponse Add(GroupMemberDTO dto)
        {
            var isNotExist = dalGroup.Any(GroupID: dto.GroupId);
            if (isNotExist)
            {
                return new BCResponse() { Errors = "Grup bulunmamaktadır." };
            }
            var isExist = _dalGroupMember.Any(GroupMemberExpect: dto.UserId);
            if (isExist)
            {
                return new BCResponse() { Errors = "Kullanıcı zaten eklidir." };
            }

            if (dto.UserId == dto.AddedUserId)
            {
                return new BCResponse() { Errors = "Kişi kendini ekleyemez" };
            }
            
            if ( _dalGroupMember.GetById(dto.AddedUserId).IsAdmin)
            {
                return new BCResponse() { Errors = "Kişi admin değilse üye ekleyemez" };
            }

            #region Map To Entity
            GroupMember entity = new GroupMember();
            entity.GroupMemberId = dto.GroupMemberId;
            entity.GroupId = dto.GroupId;
            entity.UserId = dto.UserId;
            entity.AddedUserId = dto.AddedUserId;
            entity.AddedDate = dto.AddedDate;
            entity.IsAdmin = dto.IsAdmin;
            #endregion Map To Entity

            var result = _dalGroupMember.Add(entity);
            if (result > 0)
            {
                return new BCResponse() { Value = result };
            }
            return new BCResponse() { Errors = "Kullanıcı eklenirken hata oluştu" };

        }

        public override BCResponse Delete(GroupMemberDTO dto)
        {
            var isExist = _dalGroupMember.Any(GroupMemberExpect: dto.AddedUserId);
            if (isExist)
            {
                GroupMember entity = new GroupMember();
                entity.AddedUserId = dto.AddedUserId;
                entity.GroupMemberId = dto.GroupMemberId;
                var result = _dalGroupMember.Delete(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors = "Sistem hatası." };

            }
            return new BCResponse() { Errors = "Silinmesi istenen kullanıcı grupta değil." };
        }

        public BCResponse GetAll(int groupID)
        {
            var record = _dalGroupMember.GetAll(groupID);
            if (record == null || record.Count == 0)
            {
                return new BCResponse() { Errors = "Grup bulunamadı" };
            }
            return new BCResponse() { Value = record };
        }

        public override BCResponse Update(GroupMemberDTO dto)
        {
            if (dto.GroupMemberId <= 0)
            {
                return new BCResponse() { Errors = "Hatalı Veri" };
            }
            var entity = _dalGroupMember.GetById(dto.GroupMemberId);
            if (entity != null)
            {
                entity.IsAdmin = dto.IsAdmin;
                var result = _dalGroupMember.Update(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors = "Kullanıcı eklenirken hata oluştu" };
            }


            return new BCResponse() { Errors = "Üye bulunamadı" };

        }
    }
}
