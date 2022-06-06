using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUnitOfWork
    {
        IDepartment department { get;}
        IEmployee employee { get;}
        ICard card { get;}

        void Save();
    }
}
