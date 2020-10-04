using MahorobaWare.Core.Constants;
using MahorobaWare.Core.Mvvm;
using MahorobaWare.Core.Plugin.Interface;
using MahorobaWare.Modules.Base.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MahorobaWare.Modules.Base.ViewModels
{
	public class SelectTileViewModel : RegionViewModelBase
	{
		public SelectTileViewModel(IRegionManager regionManager, IVisualPlugins plugins) : base(regionManager)
		{
			ShowPluginViewCommand = new DelegateCommand<IVisualPlugin>(ExecuteShowPluginView);
			PluginList = new ObservableCollection<IVisualPlugin>(plugins);
			PluginList.Remove(plugins.First(x => x.MainViewName == nameof(SelectTile)));

		}

		public override void OnNavigatedTo(NavigationContext navigationContext)
		{
			//do something
		}
		private void ExecuteShowPluginView(IVisualPlugin parameter)
		{
			var parameters = new NavigationParameters
			{
				{ "VisualPlugin", parameter }
			};
			RegionManager.RequestNavigate(RegionNames.MainRegion, nameof(SelectHamburgerMenu), parameters);
		}

		public DelegateCommand<IVisualPlugin> ShowPluginViewCommand { get; }

		public ObservableCollection<IVisualPlugin> PluginList { get; set; }
	}
}
