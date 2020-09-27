﻿using MahorobaWare.Core.Mahoroba.Entities.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahorobaWare.Service.ResourcesDownloader.Interface
{
	public interface IResolvePicIndexToUrl
	{
		public Uri GetCharacterHeadIcon(string PicIndex);
		public Uri GetCfgDataThe(int num);
		public Uri[] GetStamps(params CfgChat[] chat);
	}
}
