namespace DigitalMemory.WebApi.Models;

public class Video(Uri uri) : EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Uri Uri { get; set; } = uri;
    public Entry? Entry { get; set; }
    public Location? Location { get; set; }
}