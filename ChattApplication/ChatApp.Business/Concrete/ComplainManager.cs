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
    public class ComplainManager : ManagerBase<ComplainDTO>, IComplain
    {
        DalComplain _dalComplain;
        public ComplainManager(DalComplain dalComplain)
        {
            _dalComplain = dalComplain;
        }

        public override BCResponse Add(ComplainDTO dto)
        {
            if(dto.ComplainStatusId>0)
            {
                if(dto.MessageReferenceId>0)
                {
                    Complain entity = new Complain();
                    entity.MessageReferenceId = dto.MessageReferenceId;
                    entity.ComplainedOfUserId = dto.ComplainedOfUserId;
                    entity.ComplainStatusId = dto.ComplainStatusId;
                    entity.ComplainantUserId = dto.ComplainantUserId;
                    entity.ComplainDate = dto.ComplainDate;
                    var result=_dalComplain.Add(entity);
                    if (result > 0)
                    {
                        return new BCResponse() { Value = result };
                    }

                    return new BCResponse() { Errors = "Şikayet eklenirken hata oluştu" };
                }
                return new BCResponse() { Errors = "Mesajlaşmadan Şikayet edilmez." };
            }
            return new BCResponse() { Errors = "Mesajlaşma nedeni girmediniz." };
        }

        public override BCResponse Delete(ComplainDTO dto)
        {
            if (dto.ComplainId <= 0)
            {
                return new BCResponse() { Errors = "Hatalı Veri" };
            }
            var entity = _dalComplain.GetById(dto.ComplainId);
            if (entity != null)
            {
                var result = _dalComplain.Delete(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors = "Şikayet silinirken hata oluştu" };
            }
            return new BCResponse() { Errors = "Sikayet bulunamadı" };
        }

        public BCResponse GetByID(int id)
        {
            var record = _dalComplain.GetById(id);
            if (record == null)
            {
                return new BCResponse() { Errors = "Sikayet bulunamadı" };
            }
            return new BCResponse() { Value = record };
        }

        public BCResponse GetComplainByUserID(int id)
        {
            var record = _dalComplain.GetComplainByUserID(id);
            if (record == null || record.Count == 0)
            {
                return new BCResponse() { Errors = "Sikayet bulunamadı" };
            }
            return new BCResponse() { Value = record };
        }

        public BCResponse GetListAll()
        {
            var record = _dalComplain.GetListAll();
            if (record == null || record.Count == 0)
            {
                return new BCResponse() { Errors = "Sikayet bulunamadı" };
            }
            return new BCResponse() { Value = record };
        }

        public override BCResponse Update(ComplainDTO dto)
        {
            if (dto.ComplainId <= 0)
            {
                return new BCResponse() { Errors = "Hatalı Veri" };
            }
            var entity = _dalComplain.GetById(dto.ComplainId);
            if (entity != null)
            {
                entity.ComplainStatusId = dto.ComplainStatusId;
                var result = _dalComplain.Update(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors = "Şikayet güncellenirken hata oluştu" };
            }


            return new BCResponse() { Errors = "Şikayet Bulunamadı" };
        }
    }
}
