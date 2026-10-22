// init state
Console.WriteLine("miniDB starting...");

// configure api
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//routes
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
