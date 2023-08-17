using System.Collections;

namespace Models
{
    public class Person : EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
    }
}