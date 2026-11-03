using miniDB.Enums;

namespace miniDB.QueryEngine;

public class QuerySpec
{
    // type of command to executed
    public Enums.Commands Command { get; set; }

    // number of results to return, 0 = all
    public int? Number { get; set; }

    // table to query / create / alter
    public string? TableName { get; set; }

    // column names for the table
    // null == all
    public string[]? Columns { get; set; }
}
