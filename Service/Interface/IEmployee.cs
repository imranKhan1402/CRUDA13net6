using Model.CardC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IEmployee : IRepository<Employee>
    {
        void Update(Employee employee);
    }
}
