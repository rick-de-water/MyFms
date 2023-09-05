using MyFms.Domain.Models;

namespace MyFms.Application.Services;

public interface IMyFmsClient
{
	IAsyncEnumerable<Asset> GetAssets(CancellationToken cancellationToken = default);

	event EventHandler AssetsChanged;
}
