namespace HouseplantAPI.Entities;

public record class Houseplant
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Leaves { get; set; }
    public required int CategoryId { get; set; }
    public Category? Category { get; set; }
}