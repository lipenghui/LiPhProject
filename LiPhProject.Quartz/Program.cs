using LiPhProject.Quartz._Job;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddQuartz(q =>
{
    q.SchedulerId = "sch";
    q.UseMicrosoftDependencyInjectionJobFactory();
    q.UseSimpleTypeLoader();
    q.UseInMemoryStore();
    q.UseDedicatedThreadPool(x => x.MaxConcurrency = 10);
    q.ScheduleJob<HelloQuartzJob>(trigger => trigger
    .WithIdentity("testjob")
    .StartAt(DateTimeOffset.Now.AddSeconds(1))
    .WithDailyTimeIntervalSchedule(x => x.WithInterval(1, IntervalUnit.Minute))
    .WithDescription("123")
    );
});
builder.Services.AddTransient<HelloQuartzJob>();
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
