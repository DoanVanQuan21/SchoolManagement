using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Notification;

namespace SchoolManagement.Core.Managers
{
    public class NotificationManager
    {
        public static void ShowError(INotificationMessageManager notification, string header, string message)
        {
            notification
                .CreateMessage()
                .Accent("#F15B19")
                .Background("#F15B19")
                .HasHeader(header)
                .HasMessage(message)
                .Dismiss().WithButton("X", button => { })
                .Dismiss().WithDelay(TimeSpan.FromSeconds(3))
                .Queue();
        }

        public static void ShowWarn(INotificationMessageManager messageManager, string message)
        {
            messageManager.CreateMessage()
                .Accent("#E0A030")
                .Background("#333")
                .HasBadge("Warn")
                .HasHeader("Error")
                .HasMessage(message)
                .WithButton("Try again", async button => { })
                .Dismiss().WithButton("Ignore", button => { })
                .Dismiss().WithDelay(TimeSpan.FromSeconds(3))
                .Queue();
        }

        public static void ShowInfo(INotificationMessageManager manager, string message)
        {
            manager
                   .CreateMessage()
                   .Accent("#1751C3")
                   .Animates(true)
                   .Background("#333")
                   .HasBadge("Info")
                   .HasMessage(
                       message)
                   .Dismiss().WithButton("Update now", button => { })
                   .Dismiss().WithButton("Release notes", button => { })
                   .Dismiss().WithDelay(TimeSpan.FromSeconds(3))
                   .Queue();
        }

        public static void ShowSuccess(INotificationMessageManager manager, string message)
        {
            manager
                    .CreateMessage()
                    .Accent("#1751C3")
                    .Animates(true)
                    .Background("#333")
                    .HasBadge("Info")
                    .HasMessage(
                        message)
                    .Dismiss().WithButton("Update now", button => { })
                    .Dismiss().WithButton("Release notes", button => { })
                    .Dismiss().WithDelay(TimeSpan.FromSeconds(3))
                    .Queue();
        }
    }
}