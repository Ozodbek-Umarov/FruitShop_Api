namespace Domain.Entities;

public class Fruit : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}
