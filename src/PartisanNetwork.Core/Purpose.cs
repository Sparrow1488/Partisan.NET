using PartisanNetwork.Core.Contracts;

namespace PartisanNetwork.Core;

public class Purpose : Identity
{
    public string? Title { get; set; }
    public Text? Description { get; set; }
    public ICollection<Task> Plan { get; set; } = new List<Task>();
}