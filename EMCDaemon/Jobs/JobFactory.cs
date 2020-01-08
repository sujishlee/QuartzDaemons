using Quartz;
using Quartz.Simpl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMCDaemon.Jobs
{
    public class JobFactory : SimpleJobFactory
    {
        IServiceProvider _provider;
        public JobFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return (IJob)this._provider.GetService(bundle.JobDetail.JobType);
            }
            catch (Exception)
            {
                throw new SchedulerException(string.Format("Problem while instantiating job '{0}'",bundle.JobDetail.Key));
            }
        }
    }
}
