using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SatisticsDB {
	public class Config {
		private static IConfigurationRoot _config;

		public static void Setup() {
			_config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
		}

		public static IConfiguration ConnectionStrings => _config.GetSection("ConnectionStrings");
	}

}
