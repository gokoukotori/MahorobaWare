using MahorobaWare.Core.Plugin.Interface;
using MahorobaWare.Modules.Chat.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Modules.Chat
{
	public class PluginInfo : IVisualPlugin
	{
		public string Name => "チャット";

		public string MainViewName => nameof(ChatList);

		public string SettingViewName => "";
		public string PluginThemeColor => "#32CD32";
		public string Icon => "CommentTextMultiple";

		public Type SettingViewType => typeof(ChatTweetList);
	}
}
