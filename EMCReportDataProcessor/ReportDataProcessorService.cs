using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace EMCReportDataProcessor
{
    public class ReportDataProcessorService : IReportDataProcessorService
    {
        public async Task ProcessDataAsync()
        {
            Debug.WriteLine("Running ReportDataProcessorService ...");
        }
    }
}
