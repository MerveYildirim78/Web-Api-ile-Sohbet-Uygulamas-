using ChatApp.Business.Abstract;
using ChatApp.Common;
using ChatApp.Common.Dto;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;

namespace ChatApp.Business.Concrete
{
    public class FriendManager : ManagerBase<FriendDTO>, IFriend
    {
        DalFriend _dalFriend;
        public FriendManager(DalFriend dalFriend)
        {
            this._dalFriend = dalFriend;
        }

        public override BCResponse Add(FriendDTO dto)
        {


            var x = _dalFriend.Any(RequestedID: dto.RequestedUserId, RequesterID: dto.RequesterUserId);
            var y = _dalFriend.Any(RequestedID: dto.RequesterUserId, RequesterID: dto.RequestedUserId);
            if (x)
            {

                return new BCResponse() { Errors = "Aynı arkadaş tekrar eklenemez." };
            }//Daha önceden kayıt vardır.
            if (y)
            {
                if (dto.FriendStatusId == 1)
                {

                    var list = _dalFriend.GetList(dto.RequesterUserId).Where(x => x.RequesterUserId == dto.RequestedUserId).ToList();
                    if (list[0].FriendStatusId == 2)
                    {
                        return new BCResponse() { Errors = "Zaten Arkadaşsınız" };
                    }
                    list[0].FriendStatusId = 2;
                    var result2 = _dalFriend.Update((Friend)list[0]);
                    return new BCResponse() { Value = result2 };
                }
            }//Karşı taraftan istek varsa yeni eklenmez. Karşı tarafın isteği kabul edilir.

            #region Map To Entity
            Friend entity = new Friend();
            entity.FriendId = dto.FriendId;
            entity.RequesterUserId = dto.RequesterUserId;
            entity.RequestedUserId = dto.RequestedUserId;
            entity.FriendStatusId = dto.FriendStatusId;
            entity.RequestedDate = dto.RequestedDate;
            #endregion Map To Entity

            var result = _dalFriend.Add(entity);
            if (result > 0)
            {
                return new BCResponse() { Value = result };
            }
            return new BCResponse() { Errors = "Sistem Hatası" };

        }

        public override BCResponse Delete(FriendDTO dto)
        {
            var isExist = _dalFriend.Any(FriendIdExpect: dto.FriendId);
            if (!isExist)
            {
                return new BCResponse() { Errors = "Arkadaş bulunamadı." };
            }
            if (dto.FriendStatusId == 2)
            {
                Friend entity = new Friend();
                entity.FriendId = dto.FriendId;
                var result = _dalFriend.Delete(entity);
                if (result > 0)
                {
                    return new BCResponse() { Value = result };
                }
                else
                {
                    return new BCResponse() { Errors = "Arkadaş değilsiniz." };
                }
            }

            return new BCResponse() { Errors = "ARkadaş silinirken hata oluştu" };
        }

        public BCResponse GetList(int userID)
        {
            var record = _dalFriend.GetList(userID);
            if (record == null)
            {
                return new BCResponse() { Errors = "Arkadaş bulunamadı" };
            }
            return new BCResponse() { Value = record };
        }

        public override BCResponse Update(FriendDTO dto)
        {
            return new BCResponse() { Errors = "Arkadaş eklenirken hata oluştu" };
        }
        public BCResponse GetFriends()
        {
            var record = _dalFriend.GetListAll();
            if (record == null)
            {
                return new BCResponse() { Errors = "Kullanıcı bulunamadı" };
            }
            return new BCResponse() { Value = record };
        }
    }
}
