using MahorobaWare.Core.Mahoroba.Entities.Json;
using MahorobaWare.Core.Mvvm;
using MahorobaWare.Service.ServerState.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace MahorobaWare.Modules.StateView.ViewModels
{
	public class ServerStatusViewModel : RegionViewModelBase
	{

		public ReactiveCollection<Server> Status { get; set; }
		public ReactiveProperty<long> AllServerConnections { get; set; }


		public ServerStatusViewModel(IRegionManager regionManager, IServerState state) : base(regionManager)
		{
			var list = state.GetAllServerState();
			Status = new ReactiveCollection<Server>();
			Status.AddRange(list.ToList());
			AllServerConnections = new ReactiveProperty<long>
			{
				Value = list.Sum(x => x.OnlineNums)
			};

			Observable.Interval(TimeSpan.FromSeconds(10))
			.Subscribe(_ =>
			{
				var list = state.GetAllServerState();
				Status.ClearOnScheduler();
				Status.AddRangeOnScheduler(list.ToList());
				AllServerConnections.Value = list.Sum(x => x.OnlineNums);
			});

		}
		public override void OnNavigatedTo(NavigationContext navigationContext)
		{
			//do something
		}
	}
}
