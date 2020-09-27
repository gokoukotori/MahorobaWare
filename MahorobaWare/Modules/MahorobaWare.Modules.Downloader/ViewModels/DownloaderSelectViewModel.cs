using MahorobaWare.Core.Mahoroba.Entities.Cfg;
using MahorobaWare.Core.Mvvm;
using MahorobaWare.Service.ResourcesDownloader.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.ObjectExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MahorobaWare.Modules.Downloader.ViewModels
{
	public class DownloaderSelectViewModel : RegionViewModelBase
	{

		public ReactiveCollection<TargetDownload> TargetDownloads { get; set; }
		public AsyncReactiveCommand<string> DownloadCommand { get; }

		public ReactiveProperty<string> TargetDirectory { get; set; }
		public ReactiveProperty<string> Log { get; set; }
		public ReactiveProperty<bool> IsDownloading { get; set; }

		private IPictureDownloader _PictureDownloader;

		public DownloaderSelectViewModel(IRegionManager regionManager, IPictureDownloader pictureDownloader) : base(regionManager)
		{
			_PictureDownloader = pictureDownloader;
			TargetDownloads = new ReactiveCollection<TargetDownload>();
			TargetDownloads.AddOnScheduler(new TargetDownload(false, "スタンプ", "Stampsフォルダに保存されます。", Target.Stamp));
			TargetDownloads.AddOnScheduler(new TargetDownload(false, "立ち絵", "StandCharactersフォルダに保存されます。", Target.StandCharacter));
			TargetDownloads.AddOnScheduler(new TargetDownload(false, "SD立ち絵", "SdStandCharactersフォルダに保存されます。", Target.SdStandCharacter));
			TargetDownloads.AddOnScheduler(new TargetDownload(false, "エロ絵", "CharacterSexiesのキャラ名_キャラクターIDフォルダに保存されます。", Target.CharacterSexies));
			DownloadCommand = new AsyncReactiveCommand<string>();
			DownloadCommand.Subscribe(Download);
			TargetDirectory = new ReactiveProperty<string>
			{
				Value = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName
			};
			Log = new ReactiveProperty<string>
			{
				Value = ""
			};
			IsDownloading = new ReactiveProperty<bool>();
			_PictureDownloader.CreatedFileEvent += FileHandler;
			_PictureDownloader.FailureCreatedFileEvent += FailureCreatedFile;
		}
		private async Task Download(string folderPath)
		{
			Log.Value = "";
			IsDownloading.Value = true;
			foreach (var item in TargetDownloads)
			{
				if (item.IsSelected)
				{
					switch (item.DownloadTarget)
					{
						case Target.Stamp:
							await _PictureDownloader.DownloadStampsAsync(folderPath);
							break;
						case Target.StandCharacter:
							await _PictureDownloader.DownloadStandCharactersAsync(folderPath);
							await _PictureDownloader.DownloadStandHerosAsync(folderPath);
							break;
						case Target.SdStandCharacter:
							await _PictureDownloader.DownloadSdStandCharactersAsync(folderPath);
							await _PictureDownloader.DownloadSdStandHerosAsync(folderPath);
							break;
						case Target.CharacterSexies:
							await _PictureDownloader.DownloadCharacterSexiesAsync(folderPath);
							break;
						default:
							break;
					}
				}
			}
			await Task.Delay(5000);
			IsDownloading.Value = false;
		}

		private void FileHandler(object sender, string filePath)
		{
			if (sender is CfgChat)
			{
				Log.Value += filePath + "\n";
			}
			if (sender is CfgPartner)
			{
				Log.Value += filePath + "\n";
			}
			if (sender is CfgProfession)
			{
				Log.Value += filePath + "\n";
			}
		}
		private void FailureCreatedFile(object sender, Exception ex)
		{
			if (sender is CfgChat)
			{
				Log.Value += (sender as CfgChat)?.PartnerId + "：" + ex.Message + "\n";
			}
			if (sender is CfgPartner)
			{
				Log.Value += (sender as CfgPartner)?.Picindex + "：" + ex.Message + "\n";
			}
			if (sender is CfgProfession)
			{
				Log.Value += (sender as CfgProfession)?.Pid + "：" + ex.Message + "\n";
			}
		}
	}

	public class TargetDownload
	{
		public TargetDownload(bool isSelect, string name, string description, Target target)
		{
			IsSelected = isSelect;
			Name = name;
			DownloadTarget = target;
			Description = description;
		}

		public bool IsSelected { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Target DownloadTarget { get; set; }
	}

	public enum Target
	{
		Stamp = 0,
		StandCharacter,
		SdStandCharacter,
		CharacterIcon_1,
		CharacterIcon_2,
		CharacterSexies,
	}
}
