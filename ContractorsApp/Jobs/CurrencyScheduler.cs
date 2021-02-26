using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractorsApp.Jobs
{
    public class CurrencyScheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<CurrencyJob>().Build();

            ITrigger trigger = TriggerBuilder.Create() 
                .WithIdentity("trigger1", "group1")    
                .StartNow()                            
                .WithSimpleSchedule(x => x            
                    .WithIntervalInMinutes(10)         
                    .RepeatForever())                   
                .Build();                             

            await scheduler.ScheduleJob(job, trigger);  
        }
    }
}