using PartisanNetwork.Core.Contracts;

namespace PartisanNetwork.Core;

public class Document : Identity
{
    public string Title { get; set; } = string.Empty;
    public string? Uri { get; set; }
}