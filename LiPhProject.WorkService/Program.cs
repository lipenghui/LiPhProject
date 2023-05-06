using LiPhProject.WorkService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHostedService<WorkService>();

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();
