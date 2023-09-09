namespace DigitalMemory.WebApi.Models;

public class Entry : EntityBase
{
    public Entry(DateOnly date, string text) : base()
    {
        Date = date;
        Text = text;
    }

    public required DateOnly Date { get; set; }
    public required string Text { get; set; }
    public Guid? DiaryId { get; set; } = null;
    public Diary? Diary { get; set; } = null;
    public ICollection<Person>? Persons { get; set; }
    public ICollection<Picture>? Pictures { get; set; }
    public ICollection<Video>? Videos { get; set; }
    public ICollection<Location>? Locations { get; set; }
    public ICollection<Event>? Events { get; set; }
}