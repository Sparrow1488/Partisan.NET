namespace PartisanNET.Core.Contracts;

public interface IIdentity<TId>
{
    public TId Id { get; set; }
}