using MiniDB.Routing;

// init state
Console.WriteLine("miniDB starting...");

// configure api
var builder = WebApplication.CreateBuilder(args);
//routes
var app = builder.Build();
app.SetRoutes();

app.Run();
