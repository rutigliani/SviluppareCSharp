using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleHelper.Properties;

namespace ConsoleHelper
{
	public static class Common
	{
		public static string GetConnectionString()
		{
			return Settings.Default.CN;
		}
	}
}
