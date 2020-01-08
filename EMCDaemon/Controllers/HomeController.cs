using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMCDaemon.Models;
using Quartz;
using Dell.DP.EMC.ReportDataProcessor.Jobs;

namespace EMCDaemon.Controllers
{
    public class HomeController : Controller
    {
        IScheduler _scheduler;
        public HomeController(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> StartEMCReportDataProcessor()
        {
            IJobDetail job = JobBuilder.Create<EMCReportDataProcessorJob>()
                            .WithIdentity("EMCReportDataProcessorJob", "ReportDataProcessor")
                            .StoreDurably()
                            .Build();

            await _scheduler.AddJob(job, true);

            ITrigger trigger = TriggerBuilder.Create()
                                            .ForJob(job)
                                            .WithIdentity("EMCReportDataProcessorDaily", "EMCReportDataProcessorJob")
                                            .StartNow()
                                            .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
                                            .Build();

            await _scheduler.ScheduleJob(trigger);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
