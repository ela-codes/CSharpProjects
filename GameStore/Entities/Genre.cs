namespace GameStore.Entities;

public record class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
