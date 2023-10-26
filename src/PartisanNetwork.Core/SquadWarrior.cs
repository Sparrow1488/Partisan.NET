using PartisanNetwork.Core.Contracts;

namespace PartisanNetwork.Core;

public class SquadWarrior : Identity
{
    public Warrior Warrior { get; set; }
    public Squad Squad { get; set; }
    public string? CallSign { get; set; }
    // public ICollection<Task> Tasks { get; set; } = new List<Task>();
}