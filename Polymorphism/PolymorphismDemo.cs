public class PolymorphismDemo{

    public static void PolymorphismRun()
    {
     Employee employee = new Employee();
     Manager myManager = new Manager();
     myManager.MakeHrRequest();
    //  upcasting 
     Employee myEmployeeManager  = myManager;
     myEmployeeManager.MakeHrRequest();
    }
}        