using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DataLayer
{
    public class DalComplain :DalBase<Complain,ChatApplicationContext>
    {
        ChatApplicationContext chatAppContext; 
        public DalComplain()
        {
            chatAppContext = new ChatApplicationContext();
        }
        public List<Complain> GetListAll()
        {
            return chatAppContext.Complains.ToList();
        }

        public Complain? GetById(int id)
        {
            return chatAppContext.Complains.ToHashSet<Complain>().FirstOrDefault(x => x.ComplainId == id);
        }

        public List<Complain> GetComplainByUserID(int id)
        {
            return chatAppContext.Complains.Where(x => x.ComplainantUserId == id).ToList();
        }
         public bool Any(int? messageId = null, string? email=null, string? UserName = null)
        {
            return chatAppContext
                .Complains
                .Any(x =>
                (!messageId.HasValue || x.MessageReferenceId != messageId) 
            );

        }

    }
}
