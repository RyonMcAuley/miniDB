using miniDB.Models;

namespace miniDB.Commands;


public class SqlCommand
{
    public bool Handle(SqlCommandRequest command)
    {
        Console.WriteLine(command.sql);
        Console.WriteLine("here hello hi");
        if (command.sql is not null && !string.Equals(command.sql, string.Empty))
            Console.WriteLine("not empty");
        return true;
    }
}
