namespace DigitalMemory.WebApi.Dtos;

public abstract class BaseDto
{
    public BaseDto(DateTime created)
    {
        Created = created;
    }

    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}