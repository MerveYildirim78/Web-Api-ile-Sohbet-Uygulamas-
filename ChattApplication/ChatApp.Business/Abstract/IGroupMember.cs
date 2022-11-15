using ChatApp.Common;
using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Business.Abstract
{
    public interface IGroupMember
    {
        public BCResponse GetAll(int groupID);
    }
}
