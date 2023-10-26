using PartisanNET.Core.Contracts;

namespace PartisanNET.Core;

public class SquadPurpose : Identity
{
    public Purpose Purpose { get; set; }
    public Squad Squad { get; set; }
}