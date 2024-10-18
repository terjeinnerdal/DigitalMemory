namespace DigitalMemory.WebApi.Models;

public class Entry(DateOnly date, string text) : EntityBase
{
    public required DateOnly Date { get; set; } = date;
    public required string Text { get; set; } = text;
    public ICollection<Person>? Persons { get; set; }
    public ICollection<Picture>? Pictures { get; set; }
    public ICollection<Video>? Videos { get; set; }
    public ICollection<Location>? Locations { get; set; }
}