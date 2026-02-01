/// <summary>
/// Represents a full-time employee
/// </summary>
class FullTimeEmployee : Employee
{
    public double Salary { get; set; }

    public FullTimeEmployee(string name, Department dept, double salary)
        : base(name, dept)
    {
        Salary = salary;
    }

    public override string GetInfo()
    {
        return $"Full-Time: {Name}, Dept: {Department.Name}, Salary: {Salary}";
    }

    public override string ToFileString()
    {
        return $"FT|{Name}|{Department.Name}|{Salary}";
    }
}
