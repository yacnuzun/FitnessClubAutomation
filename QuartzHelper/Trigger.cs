using Quartz;
using Quartz.Impl;
using QuequeHelper.CustomerQueque;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection.Metadata;
using System.Text;

namespace QuartzHelper
{
    public class Trigger
    {
        private static async Task<IScheduler> Start()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = await schedFact.GetScheduler();
            if (!sched.IsStarted)
                sched.Start();

            return sched;
        }

        public async void ActivedMission()
        {
            IScheduler sched = await Start();

            IJobDetail Gorev = JobBuilder.Create<Mission>().WithIdentity("Gorev", null).Build();

            ISimpleTrigger TriggerGorev = (ISimpleTrigger)TriggerBuilder.Create().WithIdentity("Gorev").StartAt(DateTime.UtcNow).WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()).Build();
            sched.ScheduleJob(Gorev, TriggerGorev);
        }
    }
    
}