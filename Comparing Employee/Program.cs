using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparing_Employee
{
    class Program
    {
        public class EmployeeCompare : IEqualityComparer<Employee>, 
                                       IComparer<Employee>    
        {
            public int Compare(Employee x, Employee y)
            {
                return String.Compare(x.Name, y.Name);
            }

            public bool Equals(Employee x, Employee y)
            {
                return String.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Employee obj)
            {
                return obj.Name.GetHashCode();
            }
        }
        public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
        {
                public DepartmentCollection Add(string departmentName, Employee employee)
            {
                if (!ContainsKey(departmentName))
                {
                    Add(departmentName, new SortedSet<Employee>(new EmployeeCompare()));
                }
                this[departmentName].Add(employee);
                return this;
            }
        }
        static void Main(string[] args)
        {
            var departments = new DepartmentCollection();

            
            departments.Add("Sales",new Employee { Name = "Joy" })
                       .Add("Sales",new Employee { Name = "Scott" })
                       .Add("Sales",new Employee { Name = "Jain"});

            
            departments.Add("Engineering",new Employee { Name = "Tony" })
                       .Add("Engineering",new Employee { Name = "Adam" })
                       .Add("Engineering",new Employee { Name = "Jain" })
                       .Add("Engineering",new Employee { Name = "Jain" });



            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }
            Console.ReadKey();

        }
    }
}
