namespace DigitalMemory.WebApi.Models;

public class Picture(Uri uri) : EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Uri Uri { get; set; } = uri;
    public Entry? Entries { get; set; }
    public Location? Location { get; set; }
}