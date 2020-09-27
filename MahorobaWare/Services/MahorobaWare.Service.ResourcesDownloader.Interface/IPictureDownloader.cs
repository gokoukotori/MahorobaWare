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
		public event FileHandler CreatedFileEvent;
		public event FailureCreatedFile FailureCreatedFileEvent;
		public delegate void FileHandler(CfgChat sender, string filePath);
		public delegate void FailureCreatedFile(CfgChat sender, Exception ex);
	}
}
