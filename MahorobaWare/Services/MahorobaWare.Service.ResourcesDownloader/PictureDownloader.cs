using MahorobaWare.Core.Mahoroba.Entities.Cfg;
using MahorobaWare.Core.Mahoroba.Entities.Picture;
using MahorobaWare.Service.ResourcesDownloader.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

		public async Task DownloadStandCharactersAsync(string saveDirectory)
		{
			await DownloadStandCharactersAsync(saveDirectory, await _InternalDataDownloader.CfgPartnersAsync()).ConfigureAwait(false);
		}
		public async Task DownloadStandCharactersAsync(string saveDirectory, params CfgPartner[] cfgPartners)
		{
			foreach (var item in cfgPartners)
			{
				var uri = _ResolvePicIndexToUrl.GetStandCharacters(item);
				if (uri == null) continue;
				var fileName = Path.Combine(saveDirectory, "StandCharacters", item.Name + "_" + item.Picindex + ".png");
				try
				{
					var data = await _WebClient.DownloadDataTaskAsync(uri[0]);

					var dir = Path.GetDirectoryName(fileName);
					if (!Directory.Exists(dir))
					{
						Directory.CreateDirectory(dir);
					}
					using var fs = new FileStream(fileName, FileMode.Create);
					using var sw = new BinaryWriter(fs);
					sw.Write(data);
				}
				catch (Exception ex)
				{
					FailureCreatedFileEvent(item, ex);
					continue;
				}
				CreatedFileEvent(item, fileName);
			}
		}

		public async Task DownloadSdStandCharactersAsync(string saveDirectory)
		{
			await DownloadSdStandCharactersAsync(saveDirectory, await _InternalDataDownloader.CfgPartnersAsync()).ConfigureAwait(false);
		}
		public async Task DownloadSdStandCharactersAsync(string saveDirectory, params CfgPartner[] cfgPartners)
		{
			foreach (var item in cfgPartners)
			{
				var uri = _ResolvePicIndexToUrl.GetSdStandCharacters(item);
				if (uri == null) continue;
				var fileName = Path.Combine(saveDirectory, "SdStandCharacters", item.Name + "_" + item.Picindex + ".png");
				try
				{
					var data = await _WebClient.DownloadDataTaskAsync(uri[0]);

					var dir = Path.GetDirectoryName(fileName);
					if (!Directory.Exists(dir))
					{
						Directory.CreateDirectory(dir);
					}
					using var fs = new FileStream(fileName, FileMode.Create);
					using var sw = new BinaryWriter(fs);
					sw.Write(data);
				}
				catch (Exception ex)
				{
					FailureCreatedFileEvent(item, ex);
					continue;
				}
				CreatedFileEvent(item, fileName);
			}
		}
		public async Task DownloadStandHerosAsync(string saveDirectory)
		{
			await DownloadStandHerosAsync(saveDirectory, await _InternalDataDownloader.CfgProfessionsAsync()).ConfigureAwait(false);
		}
		public async Task DownloadStandHerosAsync(string saveDirectory, params CfgProfession[] cfgPartners)
		{
			foreach (var item in cfgPartners)
			{
				var uri = _ResolvePicIndexToUrl.GetStandHeros(item);
				if (uri == null) continue;
				var fileName = Path.Combine(saveDirectory, "StandCharacters", item.Name + "_" + item.Pid + ".png");
				try
				{
					var data = await _WebClient.DownloadDataTaskAsync(uri[0]);

					var dir = Path.GetDirectoryName(fileName);
					if (!Directory.Exists(dir))
					{
						Directory.CreateDirectory(dir);
					}
					using var fs = new FileStream(fileName, FileMode.Create);
					using var sw = new BinaryWriter(fs);
					sw.Write(data);
				}
				catch (Exception ex)
				{
					FailureCreatedFileEvent(item, ex);
					continue;
				}
				CreatedFileEvent(item, fileName);
			}
		}

		public async Task DownloadSdStandHerosAsync(string saveDirectory)
		{
			await DownloadSdStandHerosAsync(saveDirectory, await _InternalDataDownloader.CfgProfessionsAsync()).ConfigureAwait(false);
		}
		public async Task DownloadSdStandHerosAsync(string saveDirectory, params CfgProfession[] cfgPartners)
		{
			foreach (var item in cfgPartners)
			{
				var uri = _ResolvePicIndexToUrl.GetSdStandHeros(item);
				if (uri == null) continue;
				var fileName = Path.Combine(saveDirectory, "SdStandCharacters", item.Name + "_" + item.Pid + ".png");
				try
				{
					var data = await _WebClient.DownloadDataTaskAsync(uri[0]);

					var dir = Path.GetDirectoryName(fileName);
					if (!Directory.Exists(dir))
					{
						Directory.CreateDirectory(dir);
					}
					using var fs = new FileStream(fileName, FileMode.Create);
					using var sw = new BinaryWriter(fs);
					sw.Write(data);
				}
				catch (Exception ex)
				{
					FailureCreatedFileEvent(item, ex);
					continue;
				}
				CreatedFileEvent(item, fileName);
			}
		}

		public async Task DownloadCharacterSexiesAsync(string saveDirectory)
		{
			await DownloadCharacterSexiesAsync(saveDirectory, await _InternalDataDownloader.CfgPartnersAsync()).ConfigureAwait(false);
		}
		public async Task DownloadCharacterSexiesAsync(string saveDirectory, params CfgPartner[] cfgPartners)
		{
			foreach (var item in cfgPartners)
			{
				var uri = _ResolvePicIndexToUrl.GetCharacterSexies(item).First();
				if (uri == null) continue;

				for (int i = 0; i < uri.Length; i++)
				{
					var fileName = Path.Combine(saveDirectory, "CharacterSexies", item.Name + "_" + item.Picindex, item.Name + "_" + i + ".png");
					try
					{
						var data = await _WebClient.DownloadDataTaskAsync(uri[i]);

						var dir = Path.GetDirectoryName(fileName);
						if (!Directory.Exists(dir))
						{
							Directory.CreateDirectory(dir);
						}
						using var fs = new FileStream(fileName, FileMode.Create);
						using var sw = new BinaryWriter(fs);
						sw.Write(data);
					}
					catch (Exception ex)
					{
						FailureCreatedFileEvent(item, ex);
						continue;
					}
					CreatedFileEvent(item, fileName);
				}

			}
		}
	}
}
