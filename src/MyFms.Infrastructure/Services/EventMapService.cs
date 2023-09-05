using MyFms.Application.Services;

namespace MyFms.Infrastructure.Services;

public sealed class MapMoveToEventArgs : EventArgs
{
	public MapMoveToEventArgs(double latitude, double longitude)
	{
		Latitude = latitude;
		Longitude = longitude;
	}

	public double Latitude { get; }
	public double Longitude { get; }
}

public class EventMapService : IMapService
{
	public void MoveTo(double latitude, double longitude)
	{
		OnMoveTo?.Invoke(this, new MapMoveToEventArgs(latitude, longitude));
	}

	public event EventHandler<MapMoveToEventArgs>? OnMoveTo;
}
