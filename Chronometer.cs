public class Chronometer: IChronometer
{
    private DateTime m_StartTime;
    private DateTime m_LapStartTime;
    private bool m_IsStarted;
    
    public void Start()
    {
        m_StartTime = DateTime.Now;
        m_LapStartTime = m_StartTime;
        m_IsStarted = true;
    }
    
    public TimeSpan Lap()
    {
        if (!m_IsStarted)
        {
            throw new InvalidOperationException("Chronometer is not started.");
        }
        DateTime now = DateTime.Now;
        TimeSpan lap = now - m_LapStartTime;
        m_LapStartTime = now;
        return lap;
    }
    
    public TimeSpan GetTotalTime()
    {
        if (!m_IsStarted)
        {
            throw new InvalidOperationException("Chronometer is not started.");
        }
        return DateTime.Now - m_StartTime;
    }
}