using PartisanNET.Core.Contracts;

namespace PartisanNET.Core;

public class Task : Identity
{
    public string? Title { get; set; }
    public Text? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}