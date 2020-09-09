using MahorobaWare.Core.Constants;
using MahorobaWare.Modules.Base.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MahorobaWare.Modules.Base
{
	public class BaseModule : IModule
	{
		private readonly IRegionManager _regionManager;

		public BaseModule(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}

		public void OnInitialized(IContainerProvider containerProvider)
		{
			_regionManager.RequestNavigate(RegionNames.MainRegion, nameof(SelectTile));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<SelectTile>();
			containerRegistry.RegisterForNavigation<SelectHamburgerMenu>();
			containerRegistry.RegisterForNavigation<OptionMenu>();
			containerRegistry.RegisterForNavigation<WindowOption>();
		}
	}
}