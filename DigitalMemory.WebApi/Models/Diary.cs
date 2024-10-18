namespace DigitalMemory.WebApi.Models;

public class Diary(string name) : EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; } = name;
    public ICollection<Entry>? Entries { get; set; }
    public ICollection<Activity>? Activities { get; set; }
    public ICollection<Person>? Persons { get; set; }
}