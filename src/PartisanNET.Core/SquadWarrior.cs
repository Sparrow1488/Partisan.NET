using PartisanNET.Core.Contracts;

namespace PartisanNET.Core;

public class SquadWarrior : Identity
{
    public Warrior Warrior { get; set; }
    public Squad Squad { get; set; }
    public string? CallSign { get; set; }
    // public ICollection<Task> Tasks { get; set; } = new List<Task>();
}