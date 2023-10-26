using PartisanNetwork.Core.Contracts;

namespace PartisanNetwork.Core;

public class Warrior : Identity
{
    public string? Name { get; set; }
    public ICollection<Equipment> Inventory { get; set; } = new List<Equipment>();
    // public ICollection<Task> Tasks { get; set; } = new List<Task>();
}