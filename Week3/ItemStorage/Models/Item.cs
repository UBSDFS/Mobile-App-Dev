
using SQLite;

namespace ItemStorage.Models;

public class Item
{
    [PrimaryKey]
    public string ItemID { get; set; } = string.Empty;

    public string ItemName { get; set; } = string.Empty;

    public string ItemDescription { get; set; } = string.Empty;
}
