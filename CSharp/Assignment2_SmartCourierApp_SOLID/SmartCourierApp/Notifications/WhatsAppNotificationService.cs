namespace SmartCourierApp.Notifications
{
    class WhatsAppNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine("[WhatsApp] " + message);
        }
    }
}