using PartisanNetwork.Core.Contracts;

namespace PartisanNetwork.Core;

public class Text : Identity
{
    public string? Content { get; set; }
    public string? Format { get; set; }
}