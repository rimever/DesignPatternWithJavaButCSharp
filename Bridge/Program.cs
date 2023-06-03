using System;
using System.Collections.Generic;

namespace Bridge
{
    public class Employee
    {
        private string _name;
        private int _age;

        public Employee(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string GetName() => _name;

        public void SetName(string name)
        {
            _name = name;
        }

        public int GetAge() => _age;

        public void SetAge(int age)
        {
            _age = age;
        }

        public override string ToString() => $"Employee [name={_name},age={_age}]";
    }

    public abstract class DbImpl
    {
        /// <summary>
        /// Connect Database
        /// </summary>
        public abstract void Connect();
        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        public abstract List<Employee> FindAllEmployees();
        
        /// <summary>
        /// Close Database
        /// </summary>
        public abstract void Close();

    }
    public class MysqlDbImpl:DbImpl {
        public override void Connect()
        {
            Console.WriteLine("Connect MySQL");
        }

        public override List<Employee> FindAllEmployees()
        {
            // not connect Db, return create List
            var employees = new List<Employee>()
            {
                new Employee("山田", 30),
                new Employee("田中", 23)
            };
            return employees;
        }

        public override void Close()
        {
            Console.WriteLine("Close MySQL");
        }
    }

    class PostgreDbImpl:DbImpl
    {
        public override void Connect()
        {
            Console.WriteLine("Connect Postgres");
        }

        public override List<Employee> FindAllEmployees()
        {
            // not connect Db, return create List
            var employees = new List<Employee>()
            {
                new Employee("山田", 30),
                new Employee("田中", 23)
            };
            return employees;
        }

        public override void Close()
        {
            Console.WriteLine("Close Postgres");
        }
    }

    class Display
    {
        private DbImpl _impl;

        public Display(DbImpl impl)
        {
            _impl = impl;
        }

        public List<Employee> GetEmployeeList()
        {
            _impl.Connect();
            var employeeList = _impl.FindAllEmployees();
            _impl.Close();
            return employeeList;
        }

        public void ShowEmployeeList()
        {
            var employees = GetEmployeeList();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine();
        }
    }

    class CustomDisplay:Display
    {
        public CustomDisplay(DbImpl impl) : base(impl)
        {
        }

        public void FilterAge(int age)
        {
            var employees = GetEmployeeList();
            foreach (var employee in employees)
            {
                if (employee.GetAge() <= age)
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var d1 = new Display(new MysqlDbImpl());
            d1.ShowEmployeeList();

            var d2 = new CustomDisplay(new PostgreDbImpl());
            d2.ShowEmployeeList();

            var d3 = new CustomDisplay(new MysqlDbImpl());
            d3.FilterAge(25);
        }
    }
}