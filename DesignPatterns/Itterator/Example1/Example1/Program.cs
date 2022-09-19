using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeEnum = new EmployeeEnumerator();
            while(employeeEnum.MoveNext())
            {
                var employee = (Employee)employeeEnum.Current;
                Console.WriteLine("Employee with ID: {0} and Name:{1} reached.", employee.EmployeeId.ToString(), employee.EmployeeName);
            }
            Console.ReadLine();
        }
    }
}
