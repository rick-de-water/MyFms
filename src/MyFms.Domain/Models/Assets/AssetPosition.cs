namespace MyFms.Domain.Models;

public sealed class AssetPosition
{
	public required double Latitude { get; set; }
	public required double Longitude { get; set; }
	public double? Altitude { get; set; }
}
