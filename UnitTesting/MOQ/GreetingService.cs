public class NameProvider
{
    public virtual string GetName()
    {
        return "Unknown";
    }
}
public class GreetingService
{
    private readonly NameProvider _nameProvider;

    public GreetingService(NameProvider nameProvider)
    {
        _nameProvider = nameProvider;
    }

    public string CreateGreeting()
    {
        var name = _nameProvider.GetName();

        return $"Hello, {name}!";
    }
}