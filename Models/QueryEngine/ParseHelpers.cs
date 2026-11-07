namespace miniDB.QueryEngine;


public class ParseHelpers()
{
    public static async Task<QuerySpec> SelectParse(string[] words)
    {
        return new QuerySpec();
        // string[] specs = [];
        // specs[0] = "select";
        // if (words[1] == "top")
        // {
        //     if (!int.TryParse(words[2], out int result)
        //             && words[2] is not "*")
        //     {
        //         Console.WriteLine("Invalid number selected");
        //     }
        //     specs[1] = words[2];
        // }
        // else
        // {
        //     //todo if not select top */# , selecting rows.
        //     //parse rows into one specs index
        //     // this seems annoying. just do full select for now
        //     if (words[1] == "")//...
        //         return [];
        // }

        // todo WHERE
        // todo ORDER
        // also annoying
        //
        // todo JOIN yeah ok

        // return specs;
    }

    public static async Task<QuerySpec> InsertParse(string[] words)
    {
        try
        {
            // insert into {tableName} (col, col, col)
            // values (val, val, val)
            var result = new QuerySpec();
            result.Command = Enums.Commands.Insert;
            result.TableName = words[2];
            result.Columns = new string[words.Length];

            var index = 3;
            while (words[index].ToLower() != "values")
            {
                result.Columns.Append(words[index++]);
            }

            result.Values = new string[result.Columns.Length];
            // pre-increment & -1 to account for words[index] being "values"
            while (index < words.Length - 1)
            {
                result.Values.Append(words[++index]);
            }
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine("InsertParse exploded, probably array: \n" + "Exception: " + ex);
            return new QuerySpec();
        }
    }

    public static async Task<QuerySpec> CreateParse(string[] words)
    {
        // create table customers
        // (string row1 string row2)
        var result = new QuerySpec();
        result.Command = Enums.Commands.Create;

        if (words[1] != "table")
        {
            Console.WriteLine("we can only make tables :/");
            return result;
        }
        result.TableName = words[2];
        Console.WriteLine("Creating Table " + result.TableName + ": ");
        result.Columns ??= new string[words.Length];
        for (int i = 3; i < words.Length; i++)
        {
            Console.Write(words[i]);
            result.Columns.Append<string>(words[i]);
            if (i < words.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();

        return result;
    }

    public static async Task<QuerySpec> DeleteParse(string[] words)
    {
        return new QuerySpec();
        // string[] specs = [];
        // specs[0] = "delete from";
        //
        // return specs;
    }
}
