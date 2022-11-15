using ChatApp.Business.Abstract;
using ChatApp.Common;
using ChatApp.Common.Dto;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;


namespace ChatApp.Business.Concrete
{
    public class UserManager : ManagerBase<UserDTO>, IUser
    {
        DalUser _dalUser;
        public UserManager(DalUser dalUser)
        {
            _dalUser = dalUser;
        }

        public override BCResponse Add(UserDTO dto)
        {
            var isExist = _dalUser.Any(email: dto.Email);
            if(isExist)
            {
                return new BCResponse(){Errors="Aynı email ile kayıtlı başka kullanıcı bulunmaktadır." };
            }
            isExist = _dalUser.Any(UserName: dto.Username);
            if (isExist)
            {
                return new BCResponse() { Errors = "Aynı isim ile kayıtlı başka kullanıcı bulunmaktadır." };
            }
        
            
            #region Map To Entity
            User entity = new User();
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.Password = dto.Password;
            entity.Username = dto.Username;
            entity.Email = dto.Email;
            entity.ProfilePhoto = dto.ProfilePhoto;
            entity.CreateDate = dto.CreateDate;
            entity.IsActive = dto.IsActive; 
            entity.IsAdmin = dto.IsAdmin;
            #endregion Map To Entity

            if (entity.Username.Length > 2 && entity.Username.Length < 50)
            {
               var result= _dalUser.Add(entity);
                if(result >0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors="Kullanıcı eklenirken hata oluştu"};
            }
            return new BCResponse() { Errors="Kullanıcı adı uygun değil"};


        }

        public override BCResponse Delete(UserDTO dto)
        {
            var isExist = _dalUser.Any(UserIdExpect: dto.UserId);
            if (!isExist)
            {
               return new BCResponse() { Errors = "Kulanıcı bulunamadı." }; 
            }
             User entity = new User();
                entity.UserId = dto.UserId;
                var result = _dalUser.Delete(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors = "Kullanıcı silinirken hata oluştu" };
        }

        public BCResponse GetByID(int id)
        {
            var record = _dalUser.GetByID(id);
            if(record == null)
            {
                return new BCResponse() { Errors = "Kullanıcı bulunamadı" };
            }
            return new BCResponse() { Value = record };
        }

        public BCResponse GetByUsername(string userName)
        {
            var record = _dalUser.GetByUsername(userName);
            if (record == null)
            {return new BCResponse() { Errors = "Kullanıcı bulunamadı" };
                
            }return new BCResponse() { Value = record };
            
        }

        public BCResponse GetUsers()
        {
            var record = _dalUser.GetUsers();
            if (record == null || record.Count == 0)
            {
                return new BCResponse() { Errors = "Kullanıcı bulunamadı" };
            }
            return new BCResponse() { Value = record };
        }

        public override BCResponse Update(UserDTO dto)
        {
            #region Business
            if (dto.UserId<=0)
            {
                return new BCResponse() { Errors = "Hatalı Veri" };
            }
            var isExist = _dalUser.Any(email: dto.Email);
            if (isExist)
            {
                return new BCResponse() { Errors = "Aynı email ile kayıtlı başka kullanıcı bulunmaktadır." };
            }
            isExist = _dalUser.Any(UserName: dto.Username);
            if (isExist)
            {
                return new BCResponse() { Errors = "Aynı isim ile kayıtlı başka kullanıcı bulunmaktadır." };
            }

            #endregion Business
            #region Map To Entity        
            User? entity = _dalUser.GetByID(id: dto.UserId);
            if (entity == null)
            {
                return new BCResponse() { Errors = "Kayıt Bulunamadı." };
            }
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.Password = dto.Password;
            entity.Username = dto.Username;
            entity.Email = dto.Email;
            entity.ProfilePhoto = dto.ProfilePhoto;
            entity.CreateDate = dto.CreateDate;
            entity.IsActive = dto.IsActive;
            entity.IsAdmin = dto.IsAdmin;
            #endregion Map To Entity
            #region Update
            if (entity.Username.Length > 2 && entity.Username.Length < 50)
            {
                var result = _dalUser.Update(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                return new BCResponse() { Errors = "Kullanıcı bilgileri güncellenirken hata oluştu" };
            }
            #endregion Update
            return new BCResponse() { Errors = "Kullanıcı adı uygun değil" };

        }
    }
}
