using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Core.Mahoroba.Entities.Cfg
{
	public class CfgChat
	{
		public CfgChat(string sid, string chat, string partnerId)
		{
			Sid = sid;
			Chat = chat;
			PartnerId = partnerId;
		}

		public string Sid { get; set; }
		public string Chat { get; set; }
		public string PartnerId { get; set; }
	}
}
