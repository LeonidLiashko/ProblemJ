namespace ProblemJ;

public static class CommandsHelper
{
    public static Commands FromString(string command)
    {
        return command switch
        {
            "print" => Commands.Print,
            "lock" => Commands.Lock,
            "unlock" => Commands.Unlock,
            "end" => Commands.End,
            _ => Commands.Assignment //TODO check expression
        };
    }
}