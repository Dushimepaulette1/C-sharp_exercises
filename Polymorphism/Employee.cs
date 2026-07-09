public abstract class Employee{
    public abstract void MakeHrRequest();
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
    public void MoveToOffice()
    {
      Console.WriteLine("Manager moves to office.");
    }
    public void Promotion()
    {
        Console.WriteLine("An employee is getting a promotion");
    }
}
