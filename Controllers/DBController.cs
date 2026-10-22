using Microsoft.AspNetCore.Mvc;
using miniDB.Commands;
using miniDB.Models;
namespace miniDB.DBController;

[ApiController]
[Route("/api/[controller]")]
public class DBController : ControllerBase
{
    [HttpGet]
    public string Test()
    {
        return "what are u doing here";
    }

    [HttpPost]
    public bool Insert(SqlCommandRequest command)
    {
        return new SqlCommand().Handle(command);
    }
}
