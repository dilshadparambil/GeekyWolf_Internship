using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp
{
    internal class AppointmentService
    {
        private INotificationService notificationService;
        public AppointmentService(INotificationService notification) 
        { 
            notificationService = notification;
        }

        public void SendNotification(string Msg)
        {
            Console.WriteLine("\nSending msg");
            notificationService.Notify(Msg);
            Console.WriteLine("msg Sent");
        }
    }
}
