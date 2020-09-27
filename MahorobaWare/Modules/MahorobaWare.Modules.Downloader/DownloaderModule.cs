using MahorobaWare.Modules.Downloader.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MahorobaWare.Modules.Downloader
{
	public class DownloaderModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{

			containerRegistry.RegisterForNavigation<DownloaderSelect>();
			containerRegistry.RegisterForNavigation<DownloaderOption>();
		}
	}
}