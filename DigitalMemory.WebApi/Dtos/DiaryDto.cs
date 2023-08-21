namespace DigitalMemory.WebApi.Dtos;

public class DiaryDto
{
    public DiaryDto(string name) => Name = name;

    public Guid Id { get; private set; }
    public required string Name { get; set; }
    public ICollection<EntryDto>? Entries { get; set; }
    public ICollection<ActivityDto>? Activities { get; set; }
    public ICollection<PersonDto>? Persons { get; set; }
    public ICollection<EventDto>? Events { get; set; }
}