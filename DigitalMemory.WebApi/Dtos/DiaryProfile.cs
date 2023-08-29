using AutoMapper;
using DigitalMemory.Models;

namespace DigitalMemory.WebApi.Dtos;

public class DiaryProfile : Profile
{
    public DiaryProfile()
    {
        CreateMap<Diary, DiaryDto>();
        CreateMap<Entry, EntryDto>();
        CreateMap<Person, PersonDto>();

        CreateMap<DiaryDto, Diary>();
        CreateMap<EntryDto, Entry>();
        CreateMap<PersonDto, Person>();
    }
}
