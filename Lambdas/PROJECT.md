# Photo Filter

In this lab, you'll implement a photo filtering system using modern C# expression syntax. All code will be in a single file containing the Image class for storing image data and implementing filters and the Program class containing the test code.

# Tasks

## Expression-Bodied Methods

- [ ] 1. First, take a look at how the Image class uses properties to store image characteristics. You'll find properties for Brightness, Contrast, and Saturation, each initialized to 0.5 by default.

- [ ] 2. Inside the Image class, convert the CreateBrighterVersion method so that it is an expression-bodied method and returns an empty Image object.

- [ ] 3. Enhance the CreateBrighterVersion method in the Image class to create a new Image based on the current instance. The new Image should increase the current instance brightness of the image by 20% while keeping the contrast and saturation values unchanged. The method should still use expression-bodied syntax.

- [ ] 4. Add the following test code to the end of the Main() method:

    ```csharp
    // Test 1: Basic brightness adjustment
    Console.WriteLine("\n=== Testing CreateBrighterVersion ===");
    Image original = Image.CreateDarkImage();
    Image brightened = original.CreateBrighterVersion();
    Console.WriteLine($"Original: {original}");
    Console.WriteLine($"Brightened: {brightened}");
    ```

    Run the test code to verify your implementation.

    Expected output:

    ```
    === Testing CreateBrighterVersion ===
    Original: Image[B:0.10, C:0.50, S:0.50]
    Brightened: Image[B:0.12, C:0.50, S:0.50]
    ```

## Method Chaining

- [ ] 5. Review the AddBrightness() and AddSaturation() methods in the Image class. Note that they return new Image instances based on the current Image instance.

- [ ] 6. Update the BrightenThenSaturate() method in the Image class so that it is an expression-bodied method that calls AddBrightness() and AddSaturation() in a single line using method chaining.

- [ ] 7. Add the following test code to end of the Main() method:

    ```csharp
    // Test 2: Chain multiple adjustments
    Console.WriteLine("\n=== Testing BrightenThenSaturate ===");
    Image chained = original.BrightenThenSaturate(0.2, 0.1);
    Console.WriteLine($"Original: {original}");
    Console.WriteLine($"Chained: {chained}");
    ```

    Run the test code to verify your implementation.

    Expected output:

    ```
    === Testing BrightenThenSaturate ===
    Original: Image[B:0.10, C:0.50, S:0.50]
    Chained: Image[B:0.30, C:0.50, S:0.60]
    ```

## Lambda Expressions

- [ ] 8. Implement a TransformBrightness() method in the Image class. The method should:
    - Return a new Image instance based on the current one.
    - Take a lambda function as a parameter that takes a double as a parameter and returns a double.
    - The new Image Brightness should equal the current Brightness passed to the lambda function.

    A call to a new method will look like this:

    ```csharp
    Image lessBright = imageVariable.TransformBrightness(x => x - 1);
    ```

- [ ] 9. Add the following test code to the end of the Main() method:

    ```csharp
    // Test 3: Lambda transformations
    Console.WriteLine("\n=== Testing TransformBrightness ===");
    Image doubled = original.TransformBrightness(x => x * 2);
    Image halved = original.TransformBrightness(x => x / 2);
    Console.WriteLine($"Original: {original}");
    Console.WriteLine($"Doubled brightness: {doubled}");
    Console.WriteLine($"Halved brightness: {halved}");
    ```

    Run the test code to verify your implementation.

    Expected Output:

    ```
    === Testing TransformBrightness ===
    Original: Image[B:0.10, C:0.50, S:0.50]
    Doubled brightness: Image[B:0.20, C:0.50, S:0.50]
    Halved brightness: Image[B:0.05, C:0.50, S:0.50]
    ```
