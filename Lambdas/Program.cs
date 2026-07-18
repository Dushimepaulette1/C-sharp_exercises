using System;

public class Image
{
  public double Brightness { get; set; } = 0.5;
  public double Contrast { get; set; } = 0.5; 
  public double Saturation { get; set; } = 0.5;

  public static Image CreateDarkImage() => 
    new Image { Brightness = 0.1 };

  public static Image CreateBrightImage() => 
    new Image { Brightness = 0.9 };

  public override string ToString() => 
    $"Image[B:{Brightness:F2}, C:{Contrast:F2}, S:{Saturation:F2}]";

  public Image CreateBrighterVersion() =>
    new Image {
      Brightness = this.Brightness * 1.2,
      Contrast = this.Contrast,
      Saturation = this.Saturation
    };

  public Image AddBrightness(double brightAmount) =>
    new Image {
      Brightness = this.Brightness + brightAmount,
      Contrast = this.Contrast,
      Saturation = this.Saturation
    };  

  public Image AddSaturation(double satAmount) =>
    new Image {
      Brightness = this.Brightness,
      Contrast = this.Contrast,
      Saturation = this.Saturation + satAmount
    };  

  public Image BrightenThenSaturate(double brightAmount, double satAmount) =>
    AddBrightness(brightAmount).AddSaturation(satAmount);

  public Image TransformBrightness(Func<double, double> transform) =>
    new Image {
      Brightness = transform(this.Brightness),
      Contrast = this.Contrast,
      Saturation = this.Saturation
    };
}

class Program 
{
  static void Main() 
  {
    Console.WriteLine("\n=== Testing CreateBrighterVersion ===");
    Image original = Image.CreateDarkImage();
    Image brightened = original.CreateBrighterVersion();
    Console.WriteLine($"Original: {original}");
    Console.WriteLine($"Brightened: {brightened}");

    Console.WriteLine("\n=== Testing BrightenThenSaturate ===");
    Image chained = original.BrightenThenSaturate(0.2, 0.1);
    Console.WriteLine($"Original: {original}");
    Console.WriteLine($"Chained: {chained}");

    Console.WriteLine("\n=== Testing TransformBrightness ===");
    Image doubled = original.TransformBrightness(x => x * 2);
    Image halved = original.TransformBrightness(x => x / 2);
    Console.WriteLine($"Original: {original}");
    Console.WriteLine($"Doubled brightness: {doubled}");
    Console.WriteLine($"Halved brightness: {halved}");
  }
}