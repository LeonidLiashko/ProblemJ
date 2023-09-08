namespace ProblemJ;

public class CommonThreadData
{
    public int Quantum { get; }
    public ExecutionTime ExecTime { get; }
    public Variables Variables { get; }

    public CommonThreadData(int quantum, ExecutionTime execTime, Variables variables)
    {
        Quantum = quantum;
        ExecTime = execTime;
        Variables = variables;
    }
}