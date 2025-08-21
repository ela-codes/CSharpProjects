namespace HouseplantAPI.Entities;

public record class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
}