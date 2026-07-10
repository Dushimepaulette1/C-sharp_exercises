using System;

namespace LearnReferences
{
  class Program
  {
    static void Main(string[] args)
    {
      // Two references to the same object
      Encyclopedia enc1 = new Encyclopedia();
      Encyclopedia enc2 = enc1;
      enc1.CurrentPage = 31;
      enc1.Flip();
      Console.WriteLine(enc1.CurrentPage);
      Console.WriteLine(enc2.CurrentPage);
      // Both print 32

      // Referential equality when comparing reference types
      Encyclopedia d1 = new Encyclopedia(50);
      Encyclopedia d2 = new Encyclopedia(50);
      Console.WriteLine(d1 == d2);
      // Prints False

      // Value equality when comparing value types
      int int1 = 6;
      int int2 = 6;
      Console.WriteLine(int1 == int2);
      // Prints True

      // Reference to object with implemented interface
      Encyclopedia enc = new Encyclopedia(50);
      IFlippable f = enc;
      enc.Flip();
      f.Flip();
      Console.WriteLine(enc.Define());
      // This causes an error!
      // Console.WriteLine(f.Define());

      // Reference to object with inherited superclass
      Encyclopedia enc3 = new Encyclopedia(19, "Codecademy Curriculum Team", "Codecademy Encyclopedia of Coding Knowledge");
      Book benc3 = enc3;
      Console.WriteLine(enc3.Author);
      Console.WriteLine(benc3.Author);
      Console.WriteLine(enc3.Define());
      // This causes an error!
      // benc3.Define();

      // Arrays of references
      IFlippable[] flippers = new IFlippable[] {new Encyclopedia(), new Novel()};
      foreach (IFlippable flipper in flippers)
      {
        flipper.Flip();
      }
      
      // Same reference type but different behavior (using virtual/override)
      Book benc = new Encyclopedia();
      Book bk = new Book();
      Console.WriteLine(benc.Stringify());
      Console.WriteLine(bk.Stringify());
      // Output:
      // "This is a Encyclopedia object!"
      // "This is a Book object!"
      
    }
  }
}
