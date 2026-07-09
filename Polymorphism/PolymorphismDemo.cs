public class PolymorphismDemo{

    public static void PolymorphismRun()
    {
     Employee employee = new Employee();
    //  Manager myManager = new Manager();
    //  myManager.MakeHrRequest();
    //  upcasting 
    //  Employee myEmployeeManager  = myManager;
    //  myEmployeeManager.MakeHrRequest();
    //  Downcasting
    Employee myEmployeeManager = new Manager();
    Manager myManager = (Manager)myEmployeeManager;
    myManager.MoveToOffice();
    }
}        