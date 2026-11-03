namespace miniDB.QueryEngine;


public interface IQueryEngine
{
    Task<QueryResponse> ExecuteAsync(string sql);
}

