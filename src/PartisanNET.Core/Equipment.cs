using PartisanNET.Core.Contracts;
using PartisanNET.Core.Static;

namespace PartisanNET.Core;

public class Equipment : Identity
{
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string? Currency { get; set; } = Currencies.Rub;
    public Text? Description { get; set; }
    public string? Company { get; set; }
    public ICollection<Document> Documents { get; set; } = new List<Document>();
    public string? Group { get; set; }
}