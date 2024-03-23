using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btap_LinQ_2
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Department(int id, string name, List<Employee> employees)
        {
            Id = id;
            Name = name;
            Employees = employees;
        }
    }
}
