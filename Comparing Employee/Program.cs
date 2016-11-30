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
        static void Main(string[] args)
        {
            var departments = new SortedDictionary<string, SortedSet<Employee>>();

            departments.Add("Sales", new SortedSet<Employee>(new EmployeeCompare()));
            departments["Sales"].Add(new Employee { Name = "Joy" });
            departments["Sales"].Add(new Employee { Name = "Scott" });
            departments["Sales"].Add(new Employee { Name = "Jain"});

            departments.Add("Engineering", new SortedSet<Employee>(new EmployeeCompare()));
            departments["Engineering"].Add(new Employee { Name = "Tony" });
            departments["Engineering"].Add(new Employee { Name = "Adam" });
            departments["Engineering"].Add(new Employee { Name = "Jain" });
            departments["Engineering"].Add(new Employee { Name = "Jain" });



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
