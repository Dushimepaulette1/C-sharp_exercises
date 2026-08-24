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

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        var result = _calculator.Add(2, 3);

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    [TestCase(10,2,8)]
    public void Subtract_TwoNumbers_ReturnsDifference(int num1, int num2, int expectedResult)
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

    [Test]
    [TestCase(10,10, 1)]
    public void Divide_TwoNumbers_ReturnsQuotient(int x, int y, int expectedQuotient)
    {
        // Assert.Ignore("TODO: implement this test.");
        var result = _calculator.Divide(x,y);
        Assert.That(result, Is.EqualTo(expectedQuotient));
    }

    [Test]
    [TestCase(10)]
    public void IsEven_VariousNumbers_ReturnsExpectedResult(int num)
    {
        // Assert.Ignore("TODO: implement this test.");
        var result = _calculator.IsEven(num);
        Assert.That(result, Is.True);
    }
}
