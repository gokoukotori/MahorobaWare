using MahorobaWare.Service.Proxy.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace MahorobaWare.Service.Proxy
{
	public class ProxyServerService : IProxyServerService
	{
		private ProxyServer ProxyServer { get; set; }

		public void NewProxy(int usePort)
		{
			ProxyServer = new ProxyServer();

			var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, usePort, true);
			ProxyServer.AddEndPoint(explicitEndPoint);

			ProxyServer.ForwardToUpstreamGateway = true;
		}
		public void RemoveProxy()
		{
			ProxyServer.Dispose();
			ProxyServer = null;
		}

		public void StartProxy()
		{
			ProxyServer.Start();
		}

		public void StopProxy()
		{
			ProxyServer.Stop();
		}


		public void SetProxyResponseEventHandler(AsyncEventHandler<SessionEventArgs> action)
		{
			ProxyServer.BeforeResponse += action;
		}

		public void RemoveProxyResponseEventHandler(AsyncEventHandler<SessionEventArgs> action)
		{
			ProxyServer.BeforeResponse -= action;
		}

		public void SetProxyRequestEventHandler(AsyncEventHandler<SessionEventArgs> action)
		{
			ProxyServer.BeforeRequest += action;
		}

		public void RemoveProxyRequestEventHandler(AsyncEventHandler<SessionEventArgs> action)
		{
			ProxyServer.BeforeRequest -= action;
		}
	}
}
