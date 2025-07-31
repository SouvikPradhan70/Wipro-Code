//  Assignment 2: Singleton Pattern in C#


using System;

// Singleton class
public class Logger
{
    private static Logger _instance; // only one instance allowed

    // private constructor so no one can create object from outside
    private Logger() { }

    // static method to get the same instance
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    // log method
    public void Log(string message)
    {
        Console.WriteLine("[LOG] " + message);
    }
}

//Demo class to use logger
public class Application
{
    private Logger _logger;

    public Application()
    {
        _logger = Logger.GetInstance();
    }

    public void Run()
    {
        _logger.Log("Application started");
        _logger.Log("Application running");
    }
}

//Main method to show Singleton works
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Singleton Pattern Demo\n");

        // Two different classes asking for Logger
        var app1 = new Application();
        var app2 = new Application();

        app1.Run();
        app2.Run();

        // Check if both apps are using the same Logger instance
        Logger l1 = Logger.GetInstance();
        Logger l2 = Logger.GetInstance();

        if (l1 == l2)
        {
            Console.WriteLine("\n Both use the same Logger instance (Singleton works)");
        }
        else
        {
            Console.WriteLine("\n Different instances created (Singleton FAILED)");
        }
    }
}

