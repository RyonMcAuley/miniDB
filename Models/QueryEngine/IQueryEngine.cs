namespace miniDB.QueryEngine;


public interface IQueryEngine
{
    Task<QueryResult> ExecuteAsync(string sql);
}

