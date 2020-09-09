using MahorobaWare.Core.Plugin.Interface;
using MahorobaWare.Modules.StateView.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Modules.StateView
{
	public class PluginInfo : IVisualPlugin
	{
		public string Name => "接続数チェッカー";

		public string MainViewName => nameof(ServerStatus);

		public string SettingViewName => "";
		public string PluginThemeColor => "#32CD32";
		public string Icon => "Server";

		public Type SettingViewType => typeof(ServerStatus);
	}
}
