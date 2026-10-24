namespace miniDB.QueryEngine;

public class QueryEngine : IQueryEngine
{
    public async Task<QueryResult> ExecuteAsync(string sql)
    {
        var result = new QueryResult();

        result.result = "test";

        return result;
    }
}
