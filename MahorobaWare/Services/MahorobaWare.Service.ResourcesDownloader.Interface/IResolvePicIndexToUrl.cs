using MahorobaWare.Core.Mahoroba.Entities.Cfg;
using System;

namespace MahorobaWare.Service.ResourcesDownloader.Interface
{
	public interface IResolvePicIndexToUrl
	{
		public Uri GetCharacterHeadIcon(string PicIndex);
		public Uri GetCfgDataThe(int num);
		public Uri[] GetStamps(params CfgChat[] chat);
		public Uri[] GetStandCharacters(params CfgPartner[] cfgPartners);
		public Uri[] GetSdStandCharacters(params CfgPartner[] cfgPartners);
		public Uri[] GetStandHeros(params CfgProfession[] cfgProfessions);
		public Uri[] GetSdStandHeros(params CfgProfession[] cfgProfessions);
		public Uri[][] GetCharacterSexies(params CfgPartner[] cfgPartners);
	}
}
