namespace DigitalMemory.WebApi.Models;

public class Location : EntityBase
{
    public Location(string name) => Name = name;

    public required string Name { get; set; }
    public ICollection<Entry>? Entries { get; set; }
    public ICollection<Video>? Videos { get; set; }
    public ICollection<Picture>? Pictures { get; set; }
    public ICollection<Event>? Events { get; set; }
}