namespace DigitalMemory.WebApi.Models;

public abstract class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Modified { get; set; } = null;
}