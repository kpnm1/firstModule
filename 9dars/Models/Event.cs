namespace _9dars.Models;

public class Event
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public List<string> Attendees { get; set; } = new List<string>();
    public List<string> Tags { get; set; } = new List<string>();
}
