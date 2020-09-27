using MahorobaWare.Core.Plugin.Interface;
using MahorobaWare.Modules.Downloader.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Modules.Downloader
{
	public class PluginInfo : IVisualPlugin
	{
		public string Name => "ダウンローダー";

		public string MainViewName => nameof(DownloaderSelect);

		public string SettingViewName => nameof(DownloaderOption);
		public string PluginThemeColor => "#32CD32";
		public string Icon => "FileDownload";

		public Type SettingViewType => typeof(DownloaderOption);
	}
}
