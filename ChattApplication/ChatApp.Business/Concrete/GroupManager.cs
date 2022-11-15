using ChatApp.Business.Abstract;
using ChatApp.Common;
using ChatApp.Common.Dto;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Business.Concrete
{
    public class GroupManager : ManagerBase<GroupDTO>, IGroup
    {
        DalGroup _dalGroup ;
        public GroupManager(DalGroup dalGroup)
        {
            _dalGroup = dalGroup;
        }

        public override BCResponse Add(GroupDTO dto)
        {
            if (dto.Description.Length> 50)
            {
                 return new BCResponse() { Errors = "Grup açıklaması 50 karakterden fazla olmamalıdır." };
            }
            if (dto.Name.Length < 2 || dto.Name.Length > 50)
            {
                return new BCResponse() { Errors = "Grup ismi 2-50 karakter olmalıdır." };
            }

            #region Map To Entity
            Group entity = new Group();
            entity.GroupId = dto.GroupId;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.GroupProfilePhoto = dto.GroupProfilePhoto;
            entity.CreaterUserId = dto.CreaterUserId;
            entity.CreateDate = dto.CreateDate;
            entity.CreateDate = dto.CreateDate;
            #endregion Map To Entity


                var result = _dalGroup.Add(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors = "Grup kurulurken hata oluştu" };

        }

        public override BCResponse Delete(GroupDTO dto)
        {
            var isNotExist = _dalGroup.Any(GroupID:dto.GroupId);
            if (!isNotExist)
            {
                return new BCResponse() { Errors = "Grup bulunamadı." };
            }
            Group entity = new Group();
            entity.GroupId= dto.GroupId;
            var result = _dalGroup.Delete(entity);
            if (result > 0)
            {
                return new BCResponse() { Value = result };
            }
            return new BCResponse() { Errors = "Grup silinirken hata oluştu" };

        }

        public BCResponse GetList(int groupId)
        {
            var record = _dalGroup.GetList(groupId);
            if (record == null)
            {
                return new BCResponse() { Errors = "Grup bulunamadı" };
            }
            return new BCResponse() { Value = record };
        }

        public override BCResponse Update(GroupDTO dto)
        {
            if (dto.GroupId <= 0)
            {
                return new BCResponse() { Errors = "Hatalı Veri" };
            }
            if (dto.Description.Length > 50)
            {
                return new BCResponse() { Errors = "Grup açıklaması 50 karakterden fazla olmamalıdır." };
            }
            if (dto.Name.Length < 2 || dto.Name.Length > 50)
            {
                return new BCResponse() { Errors = "Grup ismi 2-50 karakter olmalıdır." };
            }

            #region Map To Entity
            Group? entity = _dalGroup.GetList(groupId: dto.GroupId);
            if (entity == null)
            {
                return new BCResponse() { Errors = "Grup Bulunamadı." };
            }

            entity.GroupId = dto.GroupId;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.GroupProfilePhoto = dto.GroupProfilePhoto;
            entity.CreaterUserId = dto.CreaterUserId;
            entity.CreateDate = dto.CreateDate;
            entity.CreateDate = dto.CreateDate;
            #endregion Map To Entity

            var result = _dalGroup.Update(entity);
            if (result > 0)
            {
                return new BCResponse() { Value = result };
            }
            return new BCResponse() { Errors = "Grup güncellenirken hata oluştu" };

        }
    }
}
