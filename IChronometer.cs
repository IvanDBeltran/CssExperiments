public interface IChronometer
{
    void Start();
    TimeSpan Lap();
    TimeSpan GetTotalTime();
}