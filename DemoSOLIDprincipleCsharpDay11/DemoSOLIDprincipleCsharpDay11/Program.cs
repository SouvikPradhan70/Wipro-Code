using DemoSOLIDprincipleCsharpDay11;
using System;
class Program
{//ex of bad design
    static void Main()
    {
        //NotifiationService service = new NotifiationService();
        //service.send("email", "Hello, this is a test email.");

        Console.WriteLine("After implementing SOLID principles here we are...");
        INotifier notifier=new EmailNotifier(); //same can be done for  SMSNotifier

        //here we are dending on interface not the concerete class
        NotificationProcssor processor = new NotificationProcssor(notifier);
        processor.Process("Welcome to the Notification app ");

    }
}
//public class NotifiationService
//{
//    public void send(string type,string message)
//    {
//        if (type == "email")
//        {
//            Console.WriteLine("Sending Email: " + message);
//        }
//        else if(type == "sms")
//        {
//            Console.WriteLine("Sending SMS: " + message);
//        }
        
//    }
    
//}
//Here SRP is violeted:-Sending mail,SMS are in one class
//OCP voilated:-(New logic break old code)
//No Abstarction :-DIP is voilated