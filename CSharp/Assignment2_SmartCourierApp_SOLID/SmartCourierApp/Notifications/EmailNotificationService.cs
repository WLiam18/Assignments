namespace SmartCourierApp.Notifications
{
    class EmailNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine("[Email] " + message);
        }
    }
}