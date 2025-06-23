public class StartCommand : ICommand
{
    private readonly IChronometer m_Chronometer;

    public StartCommand(IChronometer chronometer) => m_Chronometer = chronometer;

    public void Execute()
    {
        m_Chronometer.Start();
        Console.WriteLine("Chronometer started.");
    }
}