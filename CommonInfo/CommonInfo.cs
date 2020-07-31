using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonInfo.Properties;

namespace CommonInfo
{
	public static class Common
	{
		public static string GetConnectionString()
		{
			return Settings.Default.CN;
		}
	}
}
