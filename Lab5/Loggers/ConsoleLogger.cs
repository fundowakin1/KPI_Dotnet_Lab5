namespace Lab5.Loggers
{
    public class ConsoleLogger : Ilogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}
