using ChatApp.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Business.Concrete
{
    public abstract class ManagerBase<TManager>
        where TManager : class, new()

    {

        abstract public BCResponse Add(TManager tmanager);

        abstract public BCResponse Update(TManager tmanager);

        abstract public BCResponse Delete(TManager tmanager);

    }
    }
