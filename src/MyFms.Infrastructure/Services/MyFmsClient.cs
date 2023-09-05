using MyFms.Application.Services;
using MyFms.Domain.Models;
using System.Diagnostics;
using System.Linq;

namespace MyFms.Infrastructure.Services;

public sealed class MyFmsClient : IMyFmsClient
{
	public MyFmsClient()
	{
		_assets = Enumerable.Range(0, 20)
			.Select(i => new Asset
			{
				Name = $"Asset {i}",
				Type = (AssetType)(i % 4),
				Position = new AssetPosition
				{
					Latitude = 52.0907 + (Random.Shared.NextDouble() * 2 - 1) * 0.2,
					Longitude = 5.1214 + (Random.Shared.NextDouble() * 2 - 1) * 0.2
				}

			})
			.ToArray();

        _timer.Interval = 5000;
		_timer.Elapsed += (_, _) => OnTimerTick();
        _timer.Enabled = true;
    }

	public IAsyncEnumerable<Asset> GetAssets(CancellationToken cancellationToken = default)
	{
		// This is unsafe without copying the models,
		// but a real implementation would not be using a cache,
		// so spending time on making everything copyable would be a bit wasteful.
		return _assets.ToAsyncEnumerable();
	}

    public event EventHandler? AssetsChanged;

	private void OnTimerTick()
	{
		// Not thread safe
        foreach (var asset in _assets)
        {
            Debug.Assert(asset.Position != null);

            asset.Position.Latitude += (Random.Shared.NextDouble() * 2 - 1) * 0.001;
            asset.Position.Longitude += (Random.Shared.NextDouble() * 2 - 1) * 0.001;
        }

        AssetsChanged?.Invoke(this, EventArgs.Empty);
    }

    private readonly System.Timers.Timer _timer = new();
    private readonly Asset[] _assets;
}
