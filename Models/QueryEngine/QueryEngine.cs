using miniDB.Enums;
using miniDB.Logging;

namespace miniDB.QueryEngine;

public class QueryEngine(IMiniLogger logger) : IQueryEngine
{
    public async Task<QueryResult> ExecuteAsync(string sql)
    {
        Console.WriteLine("SQL command received: " + sql);
        var result = "";
        sql = sql.ToLower();
        string[] words = sql.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (!await ValidateCommand(words))
        {
            return new QueryResult
            {
                result = ""
            };
        }

        result = await ExecuteCommand(words);

        return new QueryResult
        {
            result = result
        };
    }

    private async Task<bool> ValidateCommand(string[] words)
    {
        //normalize command
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

    private async Task<string> ExecuteCommand(string[] words)
    {
        //placeholder determine the command and handle accordingly
        // build specs array
        string[] specs = await Parse(words);
        return "valid";
    }

    private async Task<string[]> Parse(string[] words)
    {
        if (Enum.TryParse<Enums.Commands>(words[0], out var command)
            && Enum.IsDefined(command))
        {
            return command switch
            {
                Enums.Commands.Select => await ParseHelpers.SelectParse(words),
                Enums.Commands.Create => await ParseHelpers.CreateParse(words),
                Enums.Commands.Insert => await ParseHelpers.CreateParse(words),
                Enums.Commands.Delete => await ParseHelpers.DeleteParse(words),
                _ => []
            };
        }
        logger.Log("invalid command received in Parse");
        return [];
    }
}
