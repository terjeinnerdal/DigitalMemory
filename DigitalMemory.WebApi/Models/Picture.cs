namespace DigitalMemory.WebApi.Models;

public class Picture : EntityBase
{
    public Picture(Uri uri)
    {
        Uri = uri;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public Uri Uri { get; set; }
    public Entry? Entries { get; set; }
    public Location? Location { get; set; }
}