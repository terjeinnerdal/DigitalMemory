namespace DigitalMemory.WebApi.Dtos;

public class EventDto
{
    public EventDto(string name) => Name = name;

    public Guid Id { get; private set; }
    public required string Name { get; set; }
    public EntryDto? Entry { get; set; }
    public LocationDto? Locations { get; set; }
    public ICollection<VideoDto>? Videos { get; set; }
    public DiaryDto? Diary { get; set; }
    public ICollection<PictureDto>? Pictures { get; set; }
}