namespace IntermediateCourse;

public class Person
{
    public DateTime Birthday { get; set; }

    public string Name { get => m_Name; set => m_Name = value; }
 
    private string m_Name;
    
    public int Age
    {
        get
        {
            TimeSpan timeSpan = DateTime.Now - Birthday;
            return (int)timeSpan.TotalDays / 365;
        }
    }
}