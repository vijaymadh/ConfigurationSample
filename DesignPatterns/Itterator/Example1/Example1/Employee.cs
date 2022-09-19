using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    public class Employee
    {
        private int _employeeId;
        private string _employeeName;

        public int EmployeeId { get { return _employeeId; } }
        public string EmployeeName { get { return _employeeName; } }

        public Employee(int employeeId, string employeeName)
        {
             _employeeId= employeeId;
            _employeeName = employeeName;
        }
    }
}
