using System;

namespace ExpenseTrackerApp
{
[Flags]
enum ExpenseType
{
None = 0,
Travel = 1,
Meals = 2,
OfficeSupplies = 4,
Software = 8,
Entertainment = 16
} 
public enum ApprovalStage {
        Draft = 1, 
        Submitted = 2, 
        UnderReview = 3, 
        Approved = 4,
        Rejected = 5
    }
 public class Program
    {
        public static void Main(string[] args)
        {
          string[] names = Enum.GetNames<ExpenseType>();
          foreach(string name in names)
          {
            // Console.WriteLine(name);
          }
          ExpenseType expenses = ExpenseType.Travel | ExpenseType.Meals;
          if((expenses & ExpenseType.Meals) == ExpenseType.Meals)
          {
            Console.WriteLine("Expense includes: Meals");
          }
          else
          {
            Console.WriteLine("Expense does not include: Meals");
          }
          expenses &= ~ExpenseType.Meals;
          Console.WriteLine(expenses);

          
            ExpenseType parsingVar = ExpenseType.Meals | ExpenseType.Software;
            if(Enum.TryParse<ExpenseType>(parsingVar.ToString(), out ExpenseType parsedExpense)){
              Console.WriteLine(parsedExpense);
            } else {
              Console.WriteLine("Error");
            }


            foreach(int v in Enum.GetValues(typeof(ApprovalStage)) ){
              Console.WriteLine($"Text: {v}, Numerical: {(int)v}");
            }


            if(Enum.TryParse<ApprovalStage>("Submitted", out ApprovalStage parsedStage)){
              Console.WriteLine(parsedStage);
            } else {
              Console.WriteLine("Error");
            }

            int approvalValue = 4;
            if (Enum.IsDefined(typeof(ApprovalStage), approvalValue))
            {
              ApprovalStage parsedState = (ApprovalStage) approvalValue;
              Console.WriteLine($"Parsed successfully: {parsedState}");
            }
            else
            {
              Console.WriteLine("Error Message");
            }

            ApprovalStage currentStage = ApprovalStage.UnderReview;
            switch (currentStage) 
            {
              case ApprovalStage.UnderReview:
                Console.WriteLine("Code under review");
                break;

              case ApprovalStage.Approved:
                Console.WriteLine("Approved");
                break;

              default:
                Console.WriteLine("Raise a PR");
                break;
            }

            ExpenseType validExpense = ExpenseType.OfficeSupplies | ExpenseType.Software;

            if(Enum.IsDefined(typeof(ExpenseType), "Meals")){
              Console.WriteLine("Success");
            } else {
              Console.WriteLine("Error");
            }


            currentStage = ApprovalStage.Approved;
        }
    }
}