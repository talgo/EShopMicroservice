namespace ActionFilterSample;


public record User(int Id, string Name);

public class Validation
{
    [ValidationFilter]
    public string Validate(User user)
    {
        Console.WriteLine("Test");

        return $"{user.Id}: {user.Name}";
    }
}
