namespace UnitTesting.Exercise2_StringHelper;

public class StringHelper
{
    public string Reverse(string input)
    {
        var chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    public bool IsPalindrome(string input)
    {
        var cleaned = input.Replace(" ", "").ToLower();
        return cleaned == Reverse(cleaned);
    }

    public int CountVowels(string input)
    {
        return input.ToLower().Count(c => "aeiou".Contains(c));
    }
}
