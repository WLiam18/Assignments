namespace SmartCourierApp.Notifications
{
    class SmsNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine("[SMS] " + message);
        }
    }
}