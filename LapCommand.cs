public class LapCommand : ICommand
{
    private readonly IChronometer m_Chronometer;

    public LapCommand(IChronometer chronometer) => m_Chronometer = chronometer;

    public void Execute()
    {
        try
        {
            var lap = m_Chronometer.Lap();
            Console.WriteLine($"Lap Time: {FormatTimeSpan(lap)}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private string FormatTimeSpan(TimeSpan ts) => $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}.{ts.Milliseconds:D3}";
}