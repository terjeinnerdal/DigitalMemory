namespace DigitalMemory.WebApi.Dtos;

public class DiaryDto : BaseDto
{
    public DiaryDto(string name) => Name = name;    
    public string Name { get; set; }

    public ICollection<EntryDto>? Entries { get; set; }
    public ICollection<ActivityDto>? Activities { get; set; }
    public ICollection<PersonDto>? Persons { get; set; }
    public ICollection<EventDto>? Events { get; set; }
}

//public class PostDiaryDto
//{
//    public ICollection<EntryDto>? Entries { get; set; }
//    public ICollection<ActivityDto>? Activities { get; set; }
//    public ICollection<PersonDto>? Persons { get; set; }
//    public ICollection<EventDto>? Events { get; set; }
//}
