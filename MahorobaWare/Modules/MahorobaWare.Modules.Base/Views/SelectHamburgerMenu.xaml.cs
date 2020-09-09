using CommonServiceLocator;
using MahorobaWare.Core.Constants;
using Prism.Regions;
using System.Windows.Controls;

namespace MahorobaWare.Modules.Base.Views
{
	/// <summary>
	/// Interaction logic for SelectHamburgerMenu
	/// </summary>
	public partial class SelectHamburgerMenu : UserControl
	{
		public SelectHamburgerMenu()
		{
			InitializeComponent();

			RegionManager.SetRegionName(this.PluginViewRegion, RegionNames.MenuViewRegion);

			var regionMan = ServiceLocator.Current.GetInstance<IRegionManager>();
			RegionManager.SetRegionManager(this.PluginViewRegion, regionMan);
		}
	}
}
