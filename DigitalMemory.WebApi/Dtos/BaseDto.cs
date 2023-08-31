namespace DigitalMemory.WebApi.Dtos;

public abstract class BaseDto
{
    public Guid Id { get; }
    public DateTime Created { get; }
    public DateTime? Modified { get; }

    public BaseDto()
    {
        Id = Guid.NewGuid();
        Created = DateTime.Now;
    }
}