﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp
{
    public interface INotificationService
    {
        void Notify(string message);
    }

    public class SMSNotifier : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"SMS notification : {message}");
        }
    }
    public class EmailNotifier : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email notification : {message}");
        }
    }
    public class PushNotifier : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Push notification : {message}");
        }
    }

}
