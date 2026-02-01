/// <summary>
/// Abstract base class for all employees
/// </summary>
abstract class Employee
{
    public string Name { get; set; }
    public Department Department { get; set; }

    protected Employee(string name, Department department)
    {
        Name = name;
        Department = department;
    }

    public abstract string GetInfo();
    public abstract string ToFileString();
}
