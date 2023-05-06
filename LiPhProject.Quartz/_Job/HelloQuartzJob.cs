using Quartz;

namespace LiPhProject.Quartz._Job
{
    public class HelloQuartzJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Hello Quartz.Net");
            });
        }
    }
}
