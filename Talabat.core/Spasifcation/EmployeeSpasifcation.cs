using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;

namespace Talabat.core.Spasifcation
{
    public class EmployeeSpasifcation:BaseSpasifcation<Employee>
    {
        public EmployeeSpasifcation()
        {
            AddInclud(E => E.Department);
        }
        public EmployeeSpasifcation(int id):base(E=>E.Id==id)
        {
            AddInclud(E => E.Department);
        }

    }
}
