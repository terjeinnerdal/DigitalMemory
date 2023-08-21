namespace DigitalMemory.WebApi.Dtos;

public class VideoDto
{
    public VideoDto(Uri uri) => Uri = uri;

    public Guid Id { get; set; }
    public Uri Uri { get; set; }
//    public EntryDto? Entry { get; set; }
//    public LocationDto? Location { get; set; }
//    public EventDto? Event { get; set; }
}