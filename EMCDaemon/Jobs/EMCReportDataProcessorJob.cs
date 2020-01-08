using EMCReportDataProcessor;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.DP.EMC.ReportDataProcessor.Jobs
{
    public class EMCReportDataProcessorJob : IJob
    {
        IReportDataProcessorService _service;
        public EMCReportDataProcessorJob(IReportDataProcessorService service)
        {
            _service = service;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _service.ProcessDataAsync();
        }
    }
}
