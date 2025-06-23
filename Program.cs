// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using IntermediateCourse;

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