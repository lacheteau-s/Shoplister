namespace Shoplister.Models;

public record Item
{
    public string Name { get; set; }

    public int Quantity { get; set; }

    public bool Checked { get; set; }
}