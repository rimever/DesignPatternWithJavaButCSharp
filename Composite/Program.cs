// See https://aka.ms/new-console-template for more information


var salesDepartment1 = new Department("営業１部");
var salesGroup1_1 = new Group("１課長");
var salesGroup1_2 = new Group("２課長");
salesDepartment1.Add(salesGroup1_1);
salesDepartment1.Add(salesGroup1_2);

var salesDepartment2 = new Department("営業２部");
var salesGroup2_1 = new Group("１課長");
var salesGroup2_2 = new Group("２課長");

salesDepartment2.Add(salesGroup2_1);
salesDepartment2.Add(salesGroup2_2);

var department = new Department("営業部");
department.Add(salesDepartment1);
department.Add(salesDepartment2);

department.PrintList(string.Empty);

public abstract class Unit
{
    public abstract string GetName();

    public abstract void PrintList(string prefix);

    public virtual void Add(Unit unit) {}

    public override string ToString() => GetName();
}

public class Group : Unit
{
    private String _name;

    public Group(string name)
    {
        _name = name;
    }

    public override string GetName()
    {
        return _name;
    }

    public override void PrintList(string prefix)
    {
        Console.WriteLine($"{prefix}/{this}");
    }
}

public class Department : Unit
{
    private readonly string _name;
    private readonly List<Unit> _departmentList = new List<Unit>();

    public Department(string name)
    {
        _name = name;
    }
    public override string GetName()
    {
        return _name;
    }

    public override void Add(Unit unit)
    {
        _departmentList.Add(unit);
    }


    public override void PrintList(string prefix)
    {
        Console.WriteLine($"{prefix}/{this}");
        foreach (var unit in _departmentList)
        {
            unit.PrintList($"{prefix}/{_name}");
        }
    }
}