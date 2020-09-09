using MahorobaWare.Core.Plugin.Interface;
using MahorobaWare.Modules.Base.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Modules.Base
{
	public class PluginInfo : IVisualPlugin
	{
		public string Name => "ベースモジュール";

		public string MainViewName => nameof(SelectTile);

		public string SettingViewName => nameof(WindowOption);
		public string PluginThemeColor => "#32CD32";
		public string Icon => "Home";

		public Type SettingViewType => typeof(WindowOption);
	}
}
