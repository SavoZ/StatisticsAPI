using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Topshelf;
using System.Configuration;
using StatisticsService.Job;


namespace StatisticsService {
	class Program {
		static void Main(string[] args) {
			var service = HostFactory.Run(x => {
				x.Service<Service>(s => {
					s.ConstructUsing(() => new Service());
					s.WhenStarted(async f => await f.Start());
					s.WhenStopped(f => f.Stop());
				});

				x.SetDisplayName("Statistics - Statistics");
				x.SetDescription("Service for creating Statistics");
				x.SetServiceName("Statistics - Statistics");
			});
			var exitCode = (int) Convert.ChangeType(service, service.GetTypeCode());
			Environment.ExitCode = exitCode;
		}
	}

	public class Service {
		public async Task Start() {
			Config.Setup();
				//.WithProperty("AppName", "Report - Payment Monthly Report").CreateLogger();
			var scheduleFactory = new StdSchedulerFactory();
			var scheduler = await scheduleFactory.GetScheduler();
			await scheduler.Start();

			var job = JobBuilder.Create<StatisticsJob>().WithIdentity("StatisticsJob", "StatisticsJob1").Build();
			var trigger = TriggerBuilder.Create()
				.WithIdentity("StatisticsJobTrigger", "StatisticsJobTrigger1")
				.WithCronSchedule(Config.CronTime["StatisticsCronTime"])
				.Build();

			await scheduler.ScheduleJob(job, trigger);
		}

		public void Stop() {
		}
	}
}
