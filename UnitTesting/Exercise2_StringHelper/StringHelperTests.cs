namespace UnitTesting.Exercise2_StringHelper;

[TestFixture]
public class StringHelperTests
{
    private StringHelper _stringHelper;

    [SetUp]
    public void SetUp()
    {
        _stringHelper = new StringHelper();
    }

    [Test]
    public void Reverse_SimpleWord_ReturnsReversedWord()
    {
        var result = _stringHelper.Reverse("hello");

        Assert.That(result, Is.EqualTo("olleh"));
    }

    [TestCase("racecar", true)]
    [TestCase("hello", false)]
    [TestCase("Level", true)]
    public void IsPalindrome_VariousInputs_ReturnsExpectedResult(string input, bool expected)
    {
        var result = _stringHelper.IsPalindrome(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountVowels_SimpleWord_ReturnsCorrectCount()
    {
        var result = _stringHelper.CountVowels("Education");

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Reverse_EmptyString_ReturnsEmptyString()
    {
        Assert.Ignore("TODO: implement this test.");
    }

    [Test]
    public void CountVowels_NoVowels_ReturnsZero()
    {
        Assert.Ignore("TODO: implement this test.");
    }
}
