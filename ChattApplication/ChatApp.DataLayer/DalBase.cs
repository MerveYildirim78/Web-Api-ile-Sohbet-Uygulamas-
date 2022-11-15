using ChatApp.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DataLayer
{
    public class DalBase<TDal,TContex>
        where TDal : class, new()
        where TContex : DbContext, new()

    {
        ChatApplicationContext chatAppContext = new ChatApplicationContext();
        public int Add(TDal tdal)
        {
            chatAppContext.Add(tdal);
            return chatAppContext.SaveChanges();
        }
        public int Delete(TDal tdal)
        {
            chatAppContext.Remove(tdal);
            return chatAppContext.SaveChanges();
        }
        public int Update(TDal tdal)
        {
            chatAppContext.Update(tdal);
            return chatAppContext.SaveChanges();
        }


    }
}
