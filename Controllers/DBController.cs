using Microsoft.AspNetCore.Mvc;
using miniDB.Commands;
using miniDB.Models;
namespace miniDB.DBController;

[ApiController]
[Route("/api/[controller]")]
public class DBController(SqlCommandHandler handler) : ControllerBase
{
    [HttpGet]
    public string Test()
    {
        return "what are u doing here";
    }

    [HttpPost]
    public async Task<bool> Insert(SqlCommandRequest command)
    {
        return await handler.Handle(command);
    }
}
