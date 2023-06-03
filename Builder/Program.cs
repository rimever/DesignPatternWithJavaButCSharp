using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeList = new List<Employee>
            {
                new()
                {
                    Name = "山田太郎",
                    Age = 30,
                    DepartmentName = "営業部"
                },
                new()
                {
                    Name = "田中花子",
                    Age = 28,
                    DepartmentName = "総務部"
                }
            };
            var csvBuilder = new CsvBuilder();
            var csvDirector = new Director(csvBuilder);
            csvDirector.Construct(employeeList);
            Console.WriteLine("csv");
            Console.WriteLine(csvBuilder.GetResult());

            var textBuilder = new TextBuilder();
            var textDirector = new Director(textBuilder);
            textDirector.Construct(employeeList);
            Console.WriteLine("text");
            Console.WriteLine(textBuilder.GetResult());
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string DepartmentName { get; set; }
    }

    public abstract class Builder
    {
        public abstract void CreateHeader();

        public abstract void CreateEmployeeList(List<Employee> employeeList);
    }

    public class CsvBuilder : Builder
    {
        private readonly StringBuilder _stringBuilder = new();

        public override void CreateHeader()
        {
            _stringBuilder.AppendLine("氏名,年齢,部署名");
        }

        public override void CreateEmployeeList(List<Employee> employeeList)
        {
            foreach (var item in employeeList.Select(((employee, i) => new { employee, i })))
            {
                _stringBuilder.Append($"{item.employee.Name},{item.employee.Age},{item.employee.DepartmentName}");
                if (item.i != employeeList.Count - 1)
                {
                    _stringBuilder.AppendLine();
                }
            }
        }

        public string GetResult()
        {
            return _stringBuilder.ToString();
        }
    }

    public class TextBuilder : Builder
    {
        private StringBuilder _stringBuilder = new();

        public override void CreateHeader()
        {
            _stringBuilder.AppendLine("=======================");
            _stringBuilder.AppendLine("従業員一覧");
            _stringBuilder.AppendLine("=======================");
        }

        public override void CreateEmployeeList(List<Employee> employeeList)
        {
            foreach (var employee in employeeList)
            {
                _stringBuilder.AppendLine($"氏名:{employee.Name}");
                _stringBuilder.AppendLine($"年齢:{employee.Age}");
                _stringBuilder.AppendLine($"部署名:{employee.DepartmentName}");
                _stringBuilder.AppendLine();
            }
        }

        public string GetResult()
        {
            return _stringBuilder.ToString();
        }
    }

    public class Director
    {
        private Builder _builder;

        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void Construct(List<Employee> employees)
        {
            _builder.CreateHeader();
            _builder.CreateEmployeeList(employees);
        }
    }
}