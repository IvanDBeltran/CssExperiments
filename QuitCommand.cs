public class QuitCommand : ICommand
{
    private readonly Action m_QuitCallback;

    public QuitCommand(Action quitCallback) => m_QuitCallback = quitCallback;

    public void Execute()
    {
        Console.WriteLine("Quitting Chronometer. Goodbye!");
        m_QuitCallback.Invoke();
    }
}