namespace UnitTesting.Exercise1_Calculator;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [TestCase(2, 3, 5)]
    [TestCase(-2, -3, -5)]
    [TestCase(0, 5, 5)]
    public void Add_VariousInputs_ReturnsExpectedSum(int a, int b, int expected)
    {
        var result = _calculator.Add(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(10, 2, 8)]
    [TestCase(2, 10, -8)]
    [TestCase(0, 5, -5)]
    public void Subtract_VariousInputs_ReturnsExpectedDifference(int num1, int num2, int expectedResult)
    {
        var result = _calculator.Subtract(num1, num2);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(2, 3, 6)]
    [TestCase(-2, 3, -6)]
    [TestCase(0, 5, 0)]
    public void Multiply_VariousInputs_ReturnsExpectedProduct(int a, int b, int expected)
    {
        var result = _calculator.Multiply(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
    }

// Simplifying TestCase expected values
    [TestCase(10, 10, ExpectedResult=1)]
    [TestCase(10, 4,  ExpectedResult=2.5)]
    [TestCase(-10, 2,  ExpectedResult=-5)]
    public double Divide_TwoNumbers_ReturnsQuotient(int x, int y)
    {
        return _calculator.Divide(x, y);
        // Assert.That(result, Is.EqualTo(expectedQuotient));
    }

    [TestCase(10, true)]
    [TestCase(7, false)]
    [TestCase(0, true)]
    public void IsEven_VariousNumbers_ReturnsExpectedResult(int num, bool expected)
    {
        var result = _calculator.IsEven(num);
        Assert.That(result, Is.EqualTo(expected));
    }
}
