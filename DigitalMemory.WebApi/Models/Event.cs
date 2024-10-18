namespace DigitalMemory.WebApi.Models;

public class Event(string name) : EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; } = name;
    public Entry? Entry { get; set; }
}