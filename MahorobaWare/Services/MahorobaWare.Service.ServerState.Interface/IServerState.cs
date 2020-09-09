using MahorobaWare.Core.Mahoroba.Entities.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahorobaWare.Service.ServerState.Interface
{
	public interface IServerState
	{
		public Server GetServerState(int serverId);

		public IReadOnlyList<Server> GetAllServerState();
	}
}
