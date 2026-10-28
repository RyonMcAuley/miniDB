using miniDB.QueryEngine;
using miniDB.Commands;
using miniDB.Files;
using miniDB.Logging;


// init state
Console.WriteLine("miniDB starting...");

// configure api
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IQueryEngine, QueryEngine>();
builder.Services.AddScoped<IStorageOperationsManager, StorageOperationsManager>();
builder.Services.AddScoped<IMiniLogger, MiniLogger>();
builder.Services.AddScoped<SqlCommandHandler>();
//routes
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
