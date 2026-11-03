using miniDB.Enums;
using miniDB.Logging;

namespace miniDB.QueryEngine;

public class QueryEngine(IMiniLogger logger) : IQueryEngine
{
    public async Task<QueryResponse> ExecuteAsync(string sql)
    {
        Console.WriteLine("SQL command received: " + sql);
        var result = "";
        sql = sql.ToLower();
        string[] words = sql.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (!await ValidateCommand(words))
        {
            return new QueryResponse
            {
                result = ""
            };
        }

        result = await ExecuteCommand(words);

        return new QueryResponse
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
        // array or execution object?
        //
        //placeholder determine the command and handle accordingly
        // build specs array
        QuerySpec specs = await Parse(words);
        //todo real validate on obj
        if (specs is not null && !string.IsNullOrEmpty(specs.ToString()))
        {
            return specs.ToString()!;
        }
        return "empty";
    }

    private async Task<QuerySpec> Parse(string[] words)
    {
        logger.Log("command in parse: ");
        foreach (string s in words)
        {
            logger.Log(s);
        }
        if (Enum.TryParse<Enums.Commands>(words[0], ignoreCase: true, out var command)
            && Enum.IsDefined(command))
        {
            return command switch
            {
                Enums.Commands.Select => await ParseHelpers.SelectParse(words),
                Enums.Commands.Create => await ParseHelpers.CreateParse(words),
                Enums.Commands.Insert => await ParseHelpers.InsertParse(words),
                Enums.Commands.Delete => await ParseHelpers.DeleteParse(words),
                _ => new QuerySpec()
            };
        }
        logger.Log("invalid command received in Parse: " + words[0]);
        return new QuerySpec();
    }
}
