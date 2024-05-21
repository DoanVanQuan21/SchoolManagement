using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using SchoolManagement.Core.Helpers;

namespace SchoolManagement.Core.Managers
{
    public class NotificationManager : Contracts.INotificationManager
    {
        private WindowNotificationManager? _notificationManager;

        public void InitNotification(ContentControl container, NotificationPosition position, int maxItems)
        {
            _notificationManager ??= new(TopLevel.GetTopLevel(container))
            {
                Position = position,
                MaxItems = maxItems
            };
        }

        public void ShowError(string message, int timeout = 3, Action? onClick = null, Action? onClose = null)
        {
            var timeSpan = TimeSpan.FromSeconds(timeout);
            var notifi = new Notification(Util.GetResourseString("Error_Label"), message, NotificationType.Error, timeSpan, onClick, onClose);
            _notificationManager?.Show(notifi);
        }

        public void ShowInfor(string message, int timeout = 3, Action? onClick = null, Action? onClose = null)
        {
            var timeSpan = TimeSpan.FromSeconds(timeout);
            var notifi = new Notification(Util.GetResourseString("Infor_Label"), message, NotificationType.Information, timeSpan, onClick, onClose)
            {
            };
            _notificationManager?.Show(notifi);
        }

        public void ShowSimpleText(string message, int timeout = 3, Action? onClick = null, Action? onClose = null)
        {
            _notificationManager?.Show(message);
        }

        public void ShowSuccess(string message, int timeout = 3, Action? onClick = null, Action? onClose = null)
        {
            var timeSpan = TimeSpan.FromSeconds(timeout);
            var notifi = new Notification(Util.GetResourseString("Success_Label"), message, NotificationType.Success, timeSpan, onClick, onClose);
            _notificationManager?.Show(notifi);
        }

        public void ShowWarning(string message, int timeout = 3, Action? onClick = null, Action? onClose = null)
        {
            var timeSpan = TimeSpan.FromSeconds(timeout);
            var notifi = new Notification(Util.GetResourseString("Warning_Label"), message, NotificationType.Warning, timeSpan, onClick, onClose);
            _notificationManager?.Show(notifi);
        }
    }
}