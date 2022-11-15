using ChatApp.Common;
using ChatApp.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Business.Abstract
{
    public interface IUser
    {
        public BCResponse GetUsers();
        public BCResponse GetByID(int id);
        public BCResponse GetByUsername(string userName);
    }
}
