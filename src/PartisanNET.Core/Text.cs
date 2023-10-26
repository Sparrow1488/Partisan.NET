using PartisanNET.Core.Contracts;

namespace PartisanNET.Core;

public class Text : Identity
{
    public string? Content { get; set; }
    public string? Format { get; set; }
}