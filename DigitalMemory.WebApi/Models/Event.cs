namespace DigitalMemory.WebApi.Models;

public class Event : EntityBase
{
    public Event(string name) => Name = name;

    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public Entry? Entry { get; set; }
}