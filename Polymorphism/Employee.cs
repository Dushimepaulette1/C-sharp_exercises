public class Employee{
    public virtual void MakeHrRequest()
    {
        Console.WriteLine("Making request to the HR");
    }
}
public class Engineer: Employee{
    public override void MakeHrRequest()
    {
        Console.WriteLine("Engineer Making request to the HR");
    } 
}
public class Manager: Employee {
        public override void MakeHrRequest()
    {
        Console.WriteLine("Manager Making request to the HR");
    }
}
