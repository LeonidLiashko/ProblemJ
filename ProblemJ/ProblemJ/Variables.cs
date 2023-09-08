namespace ProblemJ;

public class Variables
{
    private readonly Dictionary<char, int> _variables;

    public Variables()
    {
        _variables = new Dictionary<char, int>();
        for (var c = 'a'; c <= 'z'; c++)
        {
            _variables[c] = 0;
        }
    }
    
    public int this[char key]
    {
        get => _variables[key];
        set => _variables[key] = value;
    }
}