namespace ProblemJ;

public class ExecutionTime
{
    private readonly int[] _execTime;
    
    public ExecutionTime(IReadOnlyList<int> inputs)
    {
        if (inputs.Count != 5)
            throw new Exception($"Input execution times commands must be 5. Actual:{inputs.Count}");
        _execTime = new int[5];
        for (var i = 0; i < 5; i++)
        {
            _execTime[i] = inputs[i];
        }
    }

    public int this[Commands key]
    {
        get
        {
            switch (key)
            {
                case Commands.Print:
                    return _execTime[1];
                case Commands.Lock:
                    return _execTime[2];
                case Commands.Unlock:
                    return _execTime[3];
                case Commands.End:
                    return _execTime[4];
                case Commands.Assignment:
                    return _execTime[0];
                default:
                    throw new ArgumentOutOfRangeException(nameof(key), key, null);
            }
        }
    }
}