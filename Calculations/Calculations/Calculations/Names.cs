namespace Calculations;

public class Names
{
    public string NickName { get; set; }
    public string MakeFullName(string firstName, string lastName)
    {
        NickName = $"{firstName[0]}+{lastName[0]}";
        return $"{firstName} {lastName}";
    }
}