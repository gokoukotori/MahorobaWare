using MahApps.Metro.Controls;
using MahorobaWare.Core.Constants;
using MahorobaWare.Core.Mvvm;
using MahorobaWare.Core.Plugin;
using MahorobaWare.Core.Plugin.Interface;
using MahorobaWare.Modules.Base.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MahorobaWare.Modules.Base.ViewModels
{
	public class SelectHamburgerMenuViewModel : RegionViewModelBase
	{
		public ReactivePropertySlim<string> PluginMainViewRegion { get; set; }
		public ReactivePropertySlim<HamburgerMenuIconItem> SelectedMenu { get; set; }
		public ReactivePropertySlim<int> PluginSelectedIndex { get; set; }
		public ReactivePropertySlim<int> OptionSelectedIndex { get; set; }
		public ReactiveProperty<string> ActiveViewName { get; set; }

		private IVisualPlugins _Plugins;

		public SelectHamburgerMenuViewModel(IRegionManager regionManager, IVisualPlugins plugins) : base(regionManager)
		{
			_Plugins = plugins;
			PluginMainViewRegion = new ReactivePropertySlim<string>(RegionNames.MenuViewRegion).AddTo(Disposable);
			ActiveViewName = new ReactiveProperty<string>("").AddTo(Disposable);
			PluginList = new ObservableCollection<HamburgerMenuIconItem>(plugins.Select(ConvertTo));
			PluginList.RemoveAt(plugins.IndexOf(plugins.FirstOrDefault(x => x.MainViewName == nameof(SelectTile))));
			OptionList = new ObservableCollection<HamburgerMenuIconItem>();
			OptionList.Add(new HamburgerMenuIconItem() { Label = "Option", Icon = "Cog", Tag = nameof(OptionMenu) });
			PluginSelectedIndex = new ReactivePropertySlim<int>(-1).AddTo(Disposable);
			PluginSelectedIndex.Subscribe(OnSelectedMenu);
			OptionSelectedIndex = new ReactivePropertySlim<int>(-1).AddTo(Disposable);
			OptionSelectedIndex.Subscribe(OnSelectedOptionMenu);
		}

		public override void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (navigationContext.Parameters["VisualPlugin"] is IVisualPlugin visualPlugin)
			{
				if (PluginList.Count(x => x.Label == visualPlugin.Name) == 0)
				{
					PluginSelectedIndex.Value = -1;
					OptionSelectedIndex.Value = -1;
					ActiveViewName.Value = "";
					return;
				}
				RegionManager.RequestNavigate(PluginMainViewRegion.Value, visualPlugin.MainViewName);
				PluginSelectedIndex.Value = PluginList.IndexOf(PluginList.FirstOrDefault(x => x.Label == visualPlugin.Name && x.Icon as string == visualPlugin.Icon && x.Tag as string == visualPlugin.MainViewName));
				ActiveViewName.Value = visualPlugin.Name;
			}
		}

		public override bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public ObservableCollection<HamburgerMenuIconItem> PluginList { get; set; }
		public ObservableCollection<HamburgerMenuIconItem> OptionList { get; set; }

		private void OnSelectedMenu(int index)
		{
			if (index == -1 || PluginList[index] == null || PluginList[index].Tag == null) return;
			ActiveViewName.Value = PluginList[index].Label;
			RegionManager.RequestNavigate(PluginMainViewRegion.Value, PluginList[index].Tag as string);
		}

		private void OnSelectedOptionMenu(int index)
		{
			if (index == -1 || OptionList[index] == null || OptionList[index].Tag == null) return;
			ActiveViewName.Value = OptionList[index].Label;
			RegionManager.RequestNavigate(PluginMainViewRegion.Value, OptionList[index].Tag as string);
		}

		private HamburgerMenuIconItem ConvertTo(IVisualPlugin plugin)
		{
			if (plugin == null) return null;
			return new HamburgerMenuIconItem() { Label = plugin.Name, Icon = plugin.Icon, Tag = plugin.MainViewName };
		}
	}
}
