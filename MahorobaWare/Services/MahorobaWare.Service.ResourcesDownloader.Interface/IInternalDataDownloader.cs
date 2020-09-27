using MahorobaWare.Core.Mahoroba.Entities.Cfg;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MahorobaWare.Service.ResourcesDownloader.Interface
{
	public interface IInternalDataDownloader
	{
		public dynamic CfgData(int dataNum);
		public CfgChat[] CfgChat();
		public Task<CfgChat[]> CfgChatAsync();
		public Task<dynamic> CfgDataAsync(int dataNum);
	}
}
