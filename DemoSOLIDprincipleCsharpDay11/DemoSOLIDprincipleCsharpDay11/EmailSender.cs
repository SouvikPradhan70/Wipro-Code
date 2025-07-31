using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSOLIDprincipleCsharpDay11
{//Splitting in to dedicated class:SRP
    public class EmailSender
    {
        public void SendEmail(string message)
        {
            Console.WriteLine("Sending Email: " + message);
        }
    }
    public class SMSsender
    {
        public void SendSMS(string message)
        {
            Console.WriteLine("Sending SMS: " + message);
        }
    }

    //FOR IMPLEMENTINGG ocp: We have to use interface to entend notoofication types without changing existing code
    public interface INotifier
    {
        void Send(string message);
    }
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Sending Email: " + message);
        }

    }
    public class SMSNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Sending SMS: " + message);
        }
    }

    //LSP:Mjorly used for injecting service reference

    public class NotificationProcssor
    {
        private readonly INotifier _notifier; //ref of interface 
        public NotificationProcssor(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Process(string message)
        {
            // Here we can add additional logic if needed
            _notifier.Send(message);
        }

    }

    //ISP:Keeping all interface small and focused
    public interface IEmailSender
    {
        void SendEmail(string message);
    }
    public interface ISmsSender
    {
        void SendSMS(string message);
    }
    public class Emailsender : IEmailSender
    {//here we are not forcing sms service to implement email method and viceversa
        public void SendEmail(string message)
        {
            Console.WriteLine("Email: " + message);
        }
    }
    public class SMSSender: ISmsSender
    {
        public void SendSMS(string message)
        {
            Console.WriteLine("SMS: " + message);
        }


    }
    //Dip:
}
