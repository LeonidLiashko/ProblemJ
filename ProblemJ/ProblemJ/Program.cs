namespace ProblemJ;

public class Program
{
    public static void Main()
    {
        var commonThreadData = ReadCommonThreadData(out var numPrograms);
        var threads = CreateThreads(numPrograms, commonThreadData);
        RunThreads(threads);
    }

    private static void RunThreads(Queue<Thread> threads)
    {
        while (threads.Count > 0)
        {
            var thread = threads.Dequeue();
            thread.ExecuteCommand();
            if (thread.UnCompleted)
            {
                threads.Enqueue(thread);
            }
        }
    }

    private static Queue<Thread> CreateThreads(int numPrograms, CommonThreadData commonThreadData)
    {
        var threads = new Queue<Thread>();
        for (var id = 0; id < numPrograms; id++)
        {
            var instructions = new List<string>();
            var line = "";
            while (line != "end")
            {
                line = Console.ReadLine()?.Trim();
                if (line == null)
                    throw new Exception("'End' is missing");
                instructions.Add(line);
            }

            var thread = new Thread(id, instructions.ToArray(), commonThreadData);
            threads.Enqueue(thread);
        }

        return threads;
    }

    private static CommonThreadData ReadCommonThreadData(out int numPrograms)
    {
        var variables = new Variables();
        var inputs = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        numPrograms = inputs[0];
        var execTime = new ExecutionTime(inputs[1..6]);
        var quantum = inputs[6];
        return new CommonThreadData(quantum, execTime, variables);
    }
}