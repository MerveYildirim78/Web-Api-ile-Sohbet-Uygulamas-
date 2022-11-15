using ChatApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Business.Abstract
{
    public interface IFriend
    {
        public BCResponse GetList(int userID);

    }
}
