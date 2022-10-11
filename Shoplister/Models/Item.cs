namespace Shoplister.Models;

public record Item
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public bool Checked { get; set; }
}