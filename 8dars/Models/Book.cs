namespace _8dars.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public bool DigitalVersionAvailable { get; set; }
    public string Summary { get; set; }
    public double Price { get; set; }
    public string Edition { get; set; }
}
