using ProblemJ;

namespace ProjectJTest;

public class Tests
{
    private static StringWriter SetOutput()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        return output;
    }

    private static void SetInput(string inputText)
    {
        var input = new StringReader(inputText);
        Console.SetIn(input);
    }
    
    [Test]
    [NonParallelizable]
    public void DefaultTest()
    {
        var output = SetOutput();
        SetInput("""
                 3 1 1 1 1 1 1
                 a = 4
                 print a
                 lock
                 b = 9
                 print b
                 unlock
                 print b
                 end
                 a = 3
                 print a
                 lock
                 b = 8
                 print b
                 unlock
                 print b
                 end
                 b = 5
                 a = 17
                 print a
                 print b
                 lock
                 b = 21
                 print b
                 unlock
                 print b
                 end
                 """);
        const string expected = """
                                1: 3
                                2: 3
                                3: 17
                                3: 9
                                1: 9
                                1: 9
                                2: 8
                                2: 8
                                3: 21
                                3: 21
                                
                                """;
        expected.ReplaceLineEndings();
        Program.Main();
        Assert.That(output.ToString(), Is.EqualTo(expected));
    }
    
    [Test]
    [NonParallelizable]
    public void EmptyTest()
    {
        var output = SetOutput();
        SetInput("""
                 1 1 1 1 1 1 1
                 end
                 """);
        const string expected = "";
        expected.ReplaceLineEndings();
        
        Program.Main();
        Assert.That(output.ToString(), Is.EqualTo(expected));
    }
    
    [Test]
    [NonParallelizable]
    public void WriteTest()
    {
        var output = SetOutput();
        SetInput("""
                 1 1 1 1 1 1 1
                 print a
                 end
                 """);
        const string expected = """
                                1: 0
                                
                                """;
        expected.ReplaceLineEndings();
        
        Program.Main();
        Assert.That(output.ToString(), Is.EqualTo(expected));
    }
    
    [Test]
    [NonParallelizable]
    public void AssigmentTest()
    {
        var output = SetOutput();
        SetInput("""
                 1 1 1 1 1 1 1
                 a = 1
                 print a
                 end
                 """);
        const string expected = """
                                1: 1

                                """;
        expected.ReplaceLineEndings();
        
        Program.Main();
        Assert.That(output.ToString(), Is.EqualTo(expected));
    }
    
    [Test]
    [NonParallelizable]
    public void CommonVariablesTest()
    {
        var output = SetOutput();
        SetInput("""
                 2 1 1 1 1 1 1
                 a = 1
                 end
                 print a
                 end
                 """);
        const string expected = """
                                2: 1

                                """;
        expected.ReplaceLineEndings();
        
        Program.Main();
        Assert.That(output.ToString(), Is.EqualTo(expected));
    }
    
    [Test]
    [NonParallelizable]
    public void LockTest()
    {
        var output = SetOutput();
        SetInput("""
                 2 1 1 1 1 1 1
                 lock
                 a = 1
                 print a
                 unlock
                 end
                 lock
                 a = 2
                 print a
                 unlock
                 end
                 """);
        const string expected = """
                                1: 1
                                2: 2

                                """;
        expected.ReplaceLineEndings();
        
        Program.Main();
        Assert.That(output.ToString(), Is.EqualTo(expected));
    }
    
    [Test]
    [NonParallelizable]
    public void QuantumSizeTest()
    {
        var output = SetOutput();
        SetInput("""
                 2 1 1 1 1 1 2
                 a = 1
                 print a
                 end
                 a = 2
                 print a
                 end
                 """);
        const string expected = """
                                1: 1
                                2: 2

                                """;
        expected.ReplaceLineEndings();
        
        Program.Main();
        Assert.That(output.ToString(), Is.EqualTo(expected));
    }
    
    [Test]
    [NonParallelizable]
    public void BigExecTimeSizeTest()
    {
        var output = SetOutput();
        SetInput("""
                 1 5 5 5 5 5 2
                 a = 1
                 print a
                 end
                 """);
        const string expected = """
                                1: 1

                                """;
        expected.ReplaceLineEndings();
        
        Program.Main();
        Assert.That(output.ToString(), Is.EqualTo(expected));
    }
}