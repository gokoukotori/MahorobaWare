using System.Windows.Controls;
using System.Windows.Forms;

namespace MahorobaWare.Modules.Downloader.Views
{
	/// <summary>
	/// Interaction logic for DownloaderSelect
	/// </summary>
	public partial class DownloaderSelect : System.Windows.Controls.UserControl
	{
		public DownloaderSelect()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			using (FolderBrowserDialog dialog = new FolderBrowserDialog())
			{
				dialog.ShowNewFolderButton = true;
				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					this.FolderPath.Text = dialog.SelectedPath;
				}
			}
		}
	}
}
