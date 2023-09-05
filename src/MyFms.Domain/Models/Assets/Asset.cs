namespace MyFms.Domain.Models;

public sealed class Asset : Entity<Asset>
{
	public required string Name { get; set; }
	public required AssetType Type { get; set; }
	public AssetPosition? Position { get; set; }
}
