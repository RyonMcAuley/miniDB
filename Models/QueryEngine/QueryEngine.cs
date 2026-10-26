namespace miniDB.QueryEngine;

public class QueryEngine : IQueryEngine
{
    public async Task<QueryResult> ExecuteAsync(string sql)
    {
        var result = "";
        if (!await ValidateCommand(sql))
        {
            return new QueryResult
            {
                result = ""
            };
        }

        result = "valid";

        return new QueryResult
        {
            result = result
        };
    }

    private async Task<bool> ValidateCommand(string sql)
    {
        //normalize command
        sql = sql.ToLower();
        Console.WriteLine("SQL command received: " + sql);
        string[] words = sql.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        switch (words[0])
        {
            case "insert":
                return true;
            case "select":
                return true;
        }
        Console.WriteLine("No match found for: " + words[0]);
        return false;
    }
}
