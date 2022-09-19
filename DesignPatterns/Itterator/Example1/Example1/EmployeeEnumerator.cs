using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    public class EmployeeEnumerator : IEnumerator
    {

        private int _position;
        private ArrayList _employees = new ArrayList();

        public EmployeeEnumerator()
        {
            _position = 0;
            _employees.Add(new Employee(1, "Emp01"));
            _employees.Add(new Employee(2, "Emp02"));
            _employees.Add(new Employee(3, "Emp03"));
            _employees.Add(new Employee(4, "Emp04"));
            _employees.Add(new Employee(5, "Emp05"));
            _employees.Add(new Employee(6, "Emp06"));
        }
        public object Current
        {
            get
            {
                return _employees[_position-1];
            }
        }

        public bool MoveNext()
        {
            if (_position >= _employees.Count)
                return false;
            ++_position;
            return true;
        }

        public void Reset()
        {
            _position = 1;
        }
    }
}
