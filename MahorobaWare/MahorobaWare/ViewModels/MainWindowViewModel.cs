using MahorobaWare.Core.Constants;
using MahorobaWare.Core.Mvvm;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MahorobaWare.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private readonly IRegionManager _regionManager;
		public ReactivePropertySlim<string> Title { get; }
		public ReactivePropertySlim<string> MainRegion { get; }

		public ReactiveCommand ShowMainMenuViewCommand { get; }

		public MainWindowViewModel(IRegionManager regionManager)
		{
			Title = new ReactivePropertySlim<string>("Mahoroba").AddTo(Disposable);
			MainRegion = new ReactivePropertySlim<string>(RegionNames.MainRegion).AddTo(Disposable);

			_regionManager = regionManager;
			ShowMainMenuViewCommand = new ReactiveCommand().WithSubscribe(ExecuteMainMenuView).AddTo(Disposable);
		}
		private void ExecuteMainMenuView()
		{
			_regionManager.RequestNavigate(MainRegion.Value, "SelectTile");
		}
	}
}
