using System;
// Building a Generic Type

// As a software developer, you need to create a system for handling validated numeric amounts. 
// Your task is to create a SafeValue<T> class that ensures values meet specific validation rules before they can be stored or modified.

// The SafeValue<T> class will:

//     Protect data integrity through an IValidatable interface
//     Validate values before they are stored
//     Enforce validation rules through type constraints
//     Handle different validation scenarios


interface IValidatable
{
  public bool IsValid();
}
class SafeValue<T> where T: IValidatable
{
  T?  _value;
  private bool _hasValue = false;
  public SafeValue(T initialValue)
  {
  
    if(!initialValue.IsValid())
    {
      throw new ArgumentException("Value not found");
    }
      _value = initialValue;
      _hasValue = true;
  }
  public T? GetValue()
  {
    return _value;
  }
  public void SetValue(T value)
  {
   
    if(!value.IsValid())
    {
      throw new ArgumentException("Value not found");
    }
     _value = value;
     _hasValue = true;

  }
  public bool HasValue()
  {
    return _hasValue;
  }
}
class ValidatableAmount: IValidatable
{
  private decimal _value;
  private decimal _min;
  private decimal _max;
  public ValidatableAmount(decimal value, decimal min, decimal max)
  {
   _value = value;
   _min = min;
   _max = max;
  }
  public bool IsValid()
  {
    if(_value >= _min && _value <= _max)
    {
      return true;
    }
    else{
      return false;
    }
  }
}
class Program
{
  static void Main()
  {
    // SafeValue<int> testValue = new SafeValue<int>(42);
    

    // Console.WriteLine(testValue.GetValue());
    // testValue.SetValue(100);
    // Console.WriteLine(testValue.GetValue());
    ValidatableAmount amount = new ValidatableAmount(50, 0, 100);
    // Console.WriteLine(amount.IsValid());
    // SafeValue<ValidatableAmount> testing = new SafeValue<ValidatableAmount>(amount);
    try
    {
        ValidatableAmount invalidAmount = new ValidatableAmount(50, 0, 100);
        SafeValue<ValidatableAmount> invalidSafeValue = new SafeValue<ValidatableAmount>(invalidAmount);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine($"Error: {e.Message}");
    }

  }

}