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
                if (words[1] == "into")
                {
                    //todo verify table exists, rows valid
                    return true;
                }
                break;
            case "select":
                if (words[1] == "*" || words[1] == "top")
                {
                    //todo verify rest of structure
                    return true;
                }
                break;
            case "create":
                return true;
        }
        Console.WriteLine("No match found for: " + words[0]);
        return false;
    }
}
