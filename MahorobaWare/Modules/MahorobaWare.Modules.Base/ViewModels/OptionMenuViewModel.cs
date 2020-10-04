using MahorobaWare.Core.Constants;
using MahorobaWare.Core.Mvvm;
using MahorobaWare.Core.Plugin.Interface;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace MahorobaWare.Modules.Base.ViewModels
{
	public class OptionMenuViewModel : RegionViewModelBase
	{
		public ReactivePropertySlim<string> PluginOptionsViewRegion { get; set; }
		public OptionMenuViewModel(IRegionManager regionManager, IContainerExtension container, IVisualPlugins plugins) : base(regionManager)
		{

			PluginList = new ObservableCollection<IVisualPlugin>(plugins);
			PluginOptionsViewRegion = new ReactivePropertySlim<string>(RegionNames.PluginOptionsViewRegion).AddTo(Disposable);
			//IRegion region = regionManager.Regions[RegionNames.PluginOptionsViewRegion];
			TabItemList = new ObservableCollection<TabItem>();
			foreach (var item in PluginList)
			{
				if (item.SettingViewName?.Length == 0) continue;
				TabItemList.Add(new TabItem() { Content = container.Resolve(item.SettingViewType), Header = item.Name });
			}
		}
		public ObservableCollection<TabItem> TabItemList { get; set; }
		public ObservableCollection<IVisualPlugin> PluginList { get; set; }
	}
}
