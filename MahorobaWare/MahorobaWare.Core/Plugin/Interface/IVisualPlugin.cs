﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Core.Plugin.Interface
{
	public interface IVisualPlugin
	{
		// プラグインの名称。
		string Name { get; }

		// プラグインのメイン画面名。
		string MainViewName { get; }

		// プラグインの設定画面名。
		string SettingViewName { get; }
		Type SettingViewType { get; }

		string PluginThemeColor { get; }
		string Icon { get; }
	}
}
