using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Core.Mahoroba.Entities.Cfg
{
	public class CfgProfession
	{
		public CfgProfession(string pid, string name, string text, string offlineReport, string lines, string desc)
		{
			Pid = pid;
			Name = name;
			Text = text;
			OfflineReport = offlineReport;
			Lines = lines;
			Desc = desc;
		}

		public string Pid { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
		public string OfflineReport { get; set; }
		public string Lines { get; set; }
		public string Desc { get; set; }
	}
}
