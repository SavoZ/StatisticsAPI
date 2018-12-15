using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace StatisticsService {
	public class Config {
		private static IConfigurationRoot _config;

		public static void Setup() {
			_config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true).Build();
		}

		public static IConfiguration ConnectionStrings => _config.GetSection("ConnectionStrings");
		public static IConfiguration CronTime => _config.GetSection("CronTime");
		public static IConfiguration StatsConstants => _config.GetSection("StatsConstants");
	}
}
