/// <summary>
/// Represents a part-time employee
/// </summary>
class PartTimeEmployee : Employee
{
    public double HourlyRate { get; set; }

    public PartTimeEmployee(string name, Department dept, double rate)
        : base(name, dept)
    {
        HourlyRate = rate;
    }

    public override string GetInfo()
    {
        return $"Part-Time: {Name}, Dept: {Department.Name}, Rate: {HourlyRate}";
    }

    public override string ToFileString()
    {
        return $"PT|{Name}|{Department.Name}|{HourlyRate}";
    }
}
