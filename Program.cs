// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using IntermediateCourse;

public class ChronoConsoleUI
{
    private readonly IDictionary<string, ICommand> m_Commands;
    private readonly Action m_QuitCallback;

    public ChronoConsoleUI(IDictionary<string, ICommand> commands, Action quitCallback)
    {
        m_Commands = commands;
        m_QuitCallback = quitCallback;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            ShowMenu();
            var input = Console.ReadLine()?.Trim().ToLower();

            if (input == "q")
            {
                m_Commands["q"].Execute(); // QuitCommand will invoke _quitCallback
                isRunning = false;
            }
            else if (!string.IsNullOrEmpty(input) && m_Commands.TryGetValue(input, out var command))
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
            
        }
    }
    
    private void ShowMenu()
    {
        Console.WriteLine("\nEnter a command:");
        Console.WriteLine("(S) Start");
        Console.WriteLine("(C) Lap");
        Console.WriteLine("(E) Elapsed Time");
        Console.WriteLine("(Q) Quit");
    }
}


internal class Program
{
    public static void Main(string[] args)
    {
        var chronometer = new Chronometer();
        var commands = new Dictionary<string, ICommand>();
        var ui = new ChronoConsoleUI(commands, () => { });

        commands["s"] = new StartCommand(chronometer);
        commands["c"] = new LapCommand(chronometer);
        commands["e"] = new ElapsedTimeCommand(chronometer);
        commands["q"] = new QuitCommand(() => Console.WriteLine("Application terminated."));

        ui.Run();
        
    }
}