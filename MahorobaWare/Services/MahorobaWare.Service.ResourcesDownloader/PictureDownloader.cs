using MahorobaWare.Core.Mahoroba.Entities.Cfg;
using MahorobaWare.Core.Mahoroba.Entities.Picture;
using MahorobaWare.Service.ResourcesDownloader.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static MahorobaWare.Service.ResourcesDownloader.Interface.IPictureDownloader;

namespace MahorobaWare.Service.ResourcesDownloader
{
	public class PictureDownloader : IPictureDownloader
	{
		private WebClient _WebClient = new WebClient();
		private IResolvePicIndexToUrl _ResolvePicIndexToUrl;
		private IInternalDataDownloader _InternalDataDownloader;
		public PictureDownloader(IResolvePicIndexToUrl resolvePicIndexToUrl, IInternalDataDownloader internalDataDownloader)
		{
			_ResolvePicIndexToUrl = resolvePicIndexToUrl;
			_InternalDataDownloader = internalDataDownloader;
		}

		public void DownloadStamps(string saveDirectory)
		{
			DownloadStamps(saveDirectory, _InternalDataDownloader.CfgChat());
		}
		public void DownloadStamps(string saveDirectory ,params CfgChat[] cfgChats)
		{
			foreach (var item in cfgChats)
			{
				var uri = _ResolvePicIndexToUrl.GetStamps(item);
				if (uri == null) continue;
				var data = _WebClient.DownloadData(uri[0]);

				var dir = Path.GetDirectoryName(Path.Combine(saveDirectory, "Stamps", item.Chat + ".png"));
				if (!Directory.Exists(dir))
				{
					Directory.CreateDirectory(dir);
				}

				using var fs = new FileStream(Path.Combine(saveDirectory, "Stamps", item.Chat + ".png"), FileMode.Create);
				using var sw = new BinaryWriter(fs);
				sw.Write(data);

			}
		}

		public event FileHandler CreatedFileEvent;
		public event FailureCreatedFile FailureCreatedFileEvent;

		public async Task DownloadStampsAsync(string saveDirectory)
		{
			await DownloadStampsAsync(saveDirectory, await _InternalDataDownloader.CfgChatAsync()).ConfigureAwait(false);
		}
		public async Task DownloadStampsAsync(string saveDirectory, params CfgChat[] cfgChats)
		{
			foreach (var item in cfgChats)
			{
				var uri = _ResolvePicIndexToUrl.GetStamps(item);
				if (uri == null) continue;
				try
				{
					var data = await _WebClient.DownloadDataTaskAsync(uri[0]);

					var dir = Path.GetDirectoryName(Path.Combine(saveDirectory, "Stamps", item.Chat + ".png"));
					if (!Directory.Exists(dir))
					{
						Directory.CreateDirectory(dir);
					}

					using var fs = new FileStream(Path.Combine(saveDirectory, "Stamps", item.Chat + ".png"), FileMode.Create);
					using var sw = new BinaryWriter(fs);
					sw.Write(data);
				}
				catch (Exception ex)
				{
					FailureCreatedFileEvent(item, ex);
					continue;
				}
				CreatedFileEvent(item, Path.Combine(saveDirectory, "Stamps", item.Chat + ".png"));
			}
		}

		public StampPicture[] DownloadStampBinaries()
		{
			//DownloadStamps(_InternalDataDownloader.CfgChat());
			return null;
		}
		public StampPicture[] DownloadStampBinaries(params CfgChat[] cfgChats)
		{
			_ResolvePicIndexToUrl.GetStamps(cfgChats);
			return null;
		}
	}
}
