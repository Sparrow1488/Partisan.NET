using PartisanNetwork.Core.Contracts;

namespace PartisanNetwork.Core;

public class SquadPurpose : Identity
{
    public Purpose Purpose { get; set; }
    public Squad Squad { get; set; }
}