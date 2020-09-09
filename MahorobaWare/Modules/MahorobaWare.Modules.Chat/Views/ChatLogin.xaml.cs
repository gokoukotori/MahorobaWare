using System;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace MahorobaWare.Modules.Chat.Views
{
	/// <summary>
	/// Interaction logic for ChatLogin
	/// </summary>
	public partial class ChatLogin : UserControl
	{
		public ChatLogin()
		{
			InitializeComponent();
			SetupBrowser();
			LoginBrowser.Source = new Uri("http://pc-play.games.dmm.co.jp/play/mahoroba_x/");
		}
		private async void SetupBrowser()
		{

			CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions("--proxy-server=\"localhost:8000\"", "ja");

			CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, null, options);

			await LoginBrowser.EnsureCoreWebView2Async(env);

		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			LoginBrowser.Source = new Uri("http://pc-play.games.dmm.co.jp/play/mahoroba_x/");
		}
	}
}
