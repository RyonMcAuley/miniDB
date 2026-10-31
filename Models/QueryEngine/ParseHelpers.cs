namespace miniDB.QueryEngine;


public class ParseHelpers()
{
    public static async Task<string[]> SelectParse(string[] words)
    {
        string[] specs = [];
        specs[0] = "select";
        if (words[1] == "top")
        {
            if (!int.TryParse(words[2], out int result)
                    && words[2] is not "*")
            {
                Console.WriteLine("Invalid number selected");
            }
            specs[1] = words[2];
        }
        else
        {
            //todo if not select top */# , selecting rows.
            //parse rows into one specs index
            // this seems annoying. just do full select for now
            if (words[1] == "")//...
                return [];
        }

        // todo WHERE
        // todo ORDER
        // also annoying
        //
        // todo JOIN yeah ok

        return specs;
    }

    public static async Task<string[]> InsertParse(string[] words)
    {
        string[] specs = [];
        specs[0] = "insert into";

        return specs;
    }

    public static async Task<string[]> CreateParse(string[] words)
    {
        string[] specs = new string[words.Length];
        specs[0] = "create";

        if (words[1] != "table")
        {
            Console.WriteLine("we can only make tables :/");
            return [];
        }
        //table name
        specs[1] = words[3];
        int fill = 2;
        Console.WriteLine("Creating : \n" + words[2] + ": ");
        for (int i = 3; i < words.Length; i++)
        {
            Console.Write(words[i] + ", ");
            specs[fill++] = words[i];
        }
        Console.WriteLine();

        return specs;
    }

    public static async Task<string[]> DeleteParse(string[] words)
    {
        string[] specs = [];
        specs[0] = "delete from";

        return specs;
    }
}
