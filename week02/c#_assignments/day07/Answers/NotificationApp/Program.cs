
using NotificationApp;

INotificationService notification1 = new SMSNotifier();
AppointmentService sms = new AppointmentService(notification1);

INotificationService notification2 = new EmailNotifier();
AppointmentService email = new AppointmentService(notification2);

INotificationService notification3 = new PushNotifier();
AppointmentService push = new AppointmentService(notification3);

sms.SendNotification("hi");
email.SendNotification("how are you");
push.SendNotification("bye");