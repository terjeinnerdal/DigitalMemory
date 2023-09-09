namespace DigitalMemory.WebApi.Dtos;

public class EventDto : BaseDto
{
    public EventDto(string name) : base() => Name = name;

    public required string Name { get; set; }
    public EntryDto? Entry { get; set; }
    public LocationDto? Locations { get; set; }
    public ICollection<VideoDto>? Videos { get; set; }
    public DiaryDto? Diary { get; set; }
    public ICollection<PictureDto>? Pictures { get; set; }
}