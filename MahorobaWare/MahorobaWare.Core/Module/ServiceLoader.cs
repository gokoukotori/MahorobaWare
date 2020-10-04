using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using MahorobaWare.Core.Extensions;

namespace MahorobaWare.Core.Module
{
	public static class ServiceLoader
	{
		public static Dictionary<Type,Type> LoadServices()
		{
			var ret = new Dictionary<Type, Type>();
			var dir = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "services");
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}

			var names = Directory.GetFiles(dir);

			var interfaceServices = names.Where(x => x.Contains(".Interface.dll"));

			foreach (var item in interfaceServices)
			{
				var servicePath = names.First(x => x.Contains(item.Replace(".Interface", "")));
				var asmInter = Assembly.LoadFrom(item);
				var asmSer = Assembly.LoadFrom(servicePath);


				var inters = asmInter.GetTypes().ToArray();
				foreach (var item2 in inters)
				{
					var serviceType = asmSer.GetInterfaces(item2)[0];
					ret.Add(item2, serviceType);
				}
			}

			return ret;
		}

		public static Type? LoadService(Type interfaceType)
		{
			var dir = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName);
			//var dir = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "services");
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}

			var names = Directory.GetFiles(dir);

			foreach (var item in names.Where(x => x.Contains(".Interface.dll")).Select(x => x.Replace("Interface.", "")))
			{
				var asmSer = Assembly.LoadFrom(item);

				if(asmSer.GetInterfaces(interfaceType).Length == 0)
				{
					continue;
				}

				return asmSer.GetInterfaces(interfaceType)[0];
			}

			return null;

		}
	}
}
