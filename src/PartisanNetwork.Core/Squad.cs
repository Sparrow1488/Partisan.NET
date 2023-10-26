using PartisanNetwork.Core.Contracts;

namespace PartisanNetwork.Core;

public class Squad : Identity
{
    public string Title { get; set; } = string.Empty;
    public Text? Description { get; set; }
    public ICollection<SquadWarrior> Warriors { get; set; } = new List<SquadWarrior>();
    public ICollection<SquadPurpose> Purposes { get; set; } = new List<SquadPurpose>();

    public void AddWarrior(Warrior warrior)
    {
        Warriors.Add(new SquadWarrior
        {
            Squad = this,
            Warrior = warrior
        });
    }
    
    public void AddPurpose(Purpose purpose)
    {
        Purposes.Add(new SquadPurpose()
        {
            Squad = this,
            Purpose = purpose
        });
    }
}