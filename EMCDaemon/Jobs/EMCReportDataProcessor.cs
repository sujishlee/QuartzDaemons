using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.DP.EMC.ReportDataProcessor.Jobs
{
    public class EMCReportDataProcessor : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Debug.WriteLine("Job started");
        }
    }
}
