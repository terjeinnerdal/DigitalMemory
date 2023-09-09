namespace DigitalMemory.WebApi.Models;

public class Event : EntityBase
{
    public Event(string name) : base() => Name = name;

    public required string Name { get; set; }
    public Entry? Entry { get; set; }
    public Location? Locations { get; set; }
    public ICollection<Video>? Videos { get; set; }
    public ICollection<Diary>? Diaries { get; set; }
    public ICollection<Picture>? Pictures { get; set; }
}