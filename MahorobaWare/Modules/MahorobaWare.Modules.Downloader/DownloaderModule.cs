using MahorobaWare.Core.Module;
using MahorobaWare.Modules.Downloader.Views;
using MahorobaWare.Service.ResourcesDownloader.Interface;
using Prism.Ioc;
using Prism.Modularity;
using MahorobaWare.Service.ServerState.Interface;

namespace MahorobaWare.Modules.Downloader
{
	public class DownloaderModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			if (!containerRegistry.IsRegistered<IServerState>())
			{
				containerRegistry.RegisterSingleton(typeof(IServerState), ServiceLoader.LoadService(typeof(IServerState)));
			}

			if (!containerRegistry.IsRegistered<IResolvePicIndexToUrl>())
			{
				containerRegistry.RegisterSingleton(typeof(IResolvePicIndexToUrl), ServiceLoader.LoadService(typeof(IResolvePicIndexToUrl)));
			}

			if (!containerRegistry.IsRegistered<IInternalDataDownloader>())
			{
				containerRegistry.RegisterSingleton(typeof(IInternalDataDownloader), ServiceLoader.LoadService(typeof(IInternalDataDownloader)));
			}

			if (!containerRegistry.IsRegistered<IPictureDownloader>())
			{
				containerRegistry.RegisterSingleton(typeof(IPictureDownloader), ServiceLoader.LoadService(typeof(IPictureDownloader)));
			}
			containerRegistry.RegisterForNavigation<DownloaderSelect>();
			containerRegistry.RegisterForNavigation<DownloaderOption>();
		}
	}
}