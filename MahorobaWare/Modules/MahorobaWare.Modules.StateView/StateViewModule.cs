using MahorobaWare.Modules.StateView.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MahorobaWare.Modules.StateView
{
	public class StateViewModule : IModule
	{
		private readonly IRegionManager _regionManager;

		public StateViewModule(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<ServerStatus>();
		}
	}
}