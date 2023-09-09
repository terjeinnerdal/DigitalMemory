namespace DigitalMemory.WebApi.Models;

// todo: Will it be wise to make entry a owned entity of Diary?
// This would mean that every entry get lazyloaded when fetching a diary.
public class Diary : EntityBase
{
    public Diary(string name) : base() => Name = name;

    public required string Name { get; set; }
    public string? Description { get; set; }
    // Don't collect all Entries for a diary, should only return date and title for each.
    public ICollection<Entry>? Entries { get; set; }  
    // Don't collect all events when getting a diary, should only return title for each. 
    public ICollection<Event>? Events { get; set; }
    public ICollection<Person>? Persons { get; set; }
}