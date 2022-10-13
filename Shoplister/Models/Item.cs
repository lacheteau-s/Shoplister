using SQLite;

namespace Shoplister.Models;

[Table("Items")]
public record Item
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public bool Checked { get; set; }
}