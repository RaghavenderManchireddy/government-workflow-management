using GovernmentWorkflow.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<WorkflowDb>(o => o.UseSqlite("Data Source=workflow.db"));
builder.Services.AddCors(o => o.AddPolicy("frontend", p => p.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
var app = builder.Build();
using (var scope = app.Services.CreateScope()) { var db = scope.ServiceProvider.GetRequiredService<WorkflowDb>(); db.Database.EnsureCreated(); }
app.UseCors("frontend");
app.MapControllers();
app.Run();
