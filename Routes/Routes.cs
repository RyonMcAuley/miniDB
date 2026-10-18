namespace MiniDB.Routing;

public static class ApiRoutes
{
    public static void SetRoutes(this WebApplication app)
    {
        app.MapGet("/", () => "mini DB running...");
    }
}
