using ConsoleApp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public abstract class Logger 
    {
        public abstract void Log(string message);

    }
}
public class DatabaseLogger : Logger
{
    public override void Log(string message)
    {
        Console.WriteLine("Log written to Database: {message}");

    }
}
public class FileLogger : Logger
{
    public override void Log(string message)
    {
        Console.WriteLine("Log written to File : {message}");
    }

}
public class CloudLogger : Logger
{
    public override void Log(string message)
    {
        Console.WriteLine("Log written to Cloud : {message}");
    }
}
class Program
{
    static void Main()
    {
      
        Logger dbLogger = new DatabaseLogger();
        Logger fileLogger = new FileLogger();
        Logger cloudLogger = new CloudLogger();

       
        dbLogger.Log("This is a database log");
        fileLogger.Log("This is a file log");
        cloudLogger.Log("This is a cloud log");
    }
}
