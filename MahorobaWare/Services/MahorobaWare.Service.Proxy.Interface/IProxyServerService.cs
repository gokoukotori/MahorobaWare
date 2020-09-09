using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titanium.Web.Proxy.EventArguments;

namespace MahorobaWare.Service.Proxy.Interface
{
	public interface IProxyServerService
	{

		public void NewProxy(int usePort);
		public void RemoveProxy();

		public void StartProxy();

		public void StopProxy();


		public void SetProxyResponseEventHandler(AsyncEventHandler<SessionEventArgs> action);
		public void RemoveProxyResponseEventHandler(AsyncEventHandler<SessionEventArgs> action);
		public void SetProxyRequestEventHandler(AsyncEventHandler<SessionEventArgs> action);

		public void RemoveProxyRequestEventHandler(AsyncEventHandler<SessionEventArgs> action);
	}
}
