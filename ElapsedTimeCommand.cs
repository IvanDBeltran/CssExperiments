public class ElapsedTimeCommand : ICommand
{
    private readonly IChronometer m_Chronometer;

    public ElapsedTimeCommand(IChronometer chronometer) => m_Chronometer = chronometer;

    public void Execute()
    {
        try
        {
            var elapsed = m_Chronometer.GetTotalTime();
            Console.WriteLine($"Elapsed Time: {FormatTimeSpan(elapsed)}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private string FormatTimeSpan(TimeSpan ts) => $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}.{ts.Milliseconds:D3}";
}