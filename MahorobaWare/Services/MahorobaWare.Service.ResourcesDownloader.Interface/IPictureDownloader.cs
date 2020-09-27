using MahorobaWare.Core.Mahoroba.Entities.Cfg;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MahorobaWare.Service.ResourcesDownloader;

namespace MahorobaWare.Service.ResourcesDownloader.Interface
{
	public interface IPictureDownloader
	{
		public void DownloadStamps(string saveDirectory);
		public void DownloadStamps(string saveDirectory, params CfgChat[] cfgChats);
		public Task DownloadStampsAsync(string saveDirectory);
		public Task DownloadStampsAsync(string saveDirectory, params CfgChat[] cfgChats);
		public Task DownloadStandCharactersAsync(string saveDirectory);
		public Task DownloadStandCharactersAsync(string saveDirectory, params CfgPartner[] cfgPartners);
		public Task DownloadSdStandCharactersAsync(string saveDirectory);
		public Task DownloadSdStandCharactersAsync(string saveDirectory, params CfgPartner[] cfgPartners);
		public Task DownloadStandHerosAsync(string saveDirectory);
		public Task DownloadStandHerosAsync(string saveDirectory, params CfgProfession[] cfgPartners);
		public Task DownloadSdStandHerosAsync(string saveDirectory);
		public Task DownloadSdStandHerosAsync(string saveDirectory, params CfgProfession[] cfgPartners);
		public Task DownloadCharacterSexiesAsync(string saveDirectory);
		public Task DownloadCharacterSexiesAsync(string saveDirectory, params CfgPartner[] cfgPartners);

		public event FileHandler CreatedFileEvent;
		public event FailureCreatedFile FailureCreatedFileEvent;
		public delegate void FileHandler(object sender, string filePath);
		public delegate void FailureCreatedFile(object sender, Exception ex);
	}
}
