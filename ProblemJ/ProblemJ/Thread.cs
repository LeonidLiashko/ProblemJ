namespace ProblemJ;

public class Thread
{
    public bool UnCompleted => InstructionIndices < InstructionsCount;

    private int Id { get; }
    private int Quantum { get; set; } 
    private int InstructionsCount => _instructions.Length;
    private string CurrentInstruction => _instructions[InstructionIndices];
    private int InstructionIndices { get; set; }
    private static bool _isLocked;
    private readonly string[] _instructions;
    private readonly CommonThreadData _commonThreadData;
    private int QuantumSize => _commonThreadData.Quantum;
    private ExecutionTime ExecutionTime => _commonThreadData.ExecTime;
    private Variables Variables => _commonThreadData.Variables;

    public Thread(int id, string[] instructions, CommonThreadData commonThreadData)
    {
        _instructions = instructions;
        _commonThreadData = commonThreadData;
        Id = id;
        InstructionIndices = 0;
    }

    public void ExecuteCommand()
    {
        Quantum = QuantumSize;
        while (Quantum > 0 && UnCompleted)
        {
            var splitInstruction = CurrentInstruction.Split(' ');
            var command = CommandsHelper.FromString(splitInstruction[0]);
            switch (command)
            {
                case Commands.Print:
                    var varPrint = splitInstruction[1][0];
                    Console.WriteLine($"{Id + 1}: {Variables[varPrint]}");
                    ExecuteCommand(command);
                    break;
                case Commands.Lock:
                    if (_isLocked)
                    {
                        Quantum = 0;  // Make sure it breaks out of loop
                        break;
                    }
                    _isLocked = true;
                    ExecuteCommand(command);
                    break;
                case Commands.Unlock:
                    _isLocked = false;
                    ExecuteCommand(command);
                    break;
                case Commands.End:
                    ExecuteCommand(command);
                    break;
                case Commands.Assignment:
                    var varAssign = splitInstruction[0][0];
                    var valAssign = int.Parse(splitInstruction[2]);
                    Variables[varAssign] = valAssign;
                    ExecuteCommand(command);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void ExecuteCommand(Commands command)
    {
        Quantum -= ExecutionTime[command];
        InstructionIndices++;
    }
}