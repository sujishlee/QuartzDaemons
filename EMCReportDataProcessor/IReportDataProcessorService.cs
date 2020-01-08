using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMCReportDataProcessor
{
    public interface IReportDataProcessorService
    {
        Task ProcessDataAsync();
    }
}
