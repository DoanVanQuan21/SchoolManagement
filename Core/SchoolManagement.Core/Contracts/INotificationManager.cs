using Avalonia.Controls;
using Avalonia.Controls.Notifications;

namespace SchoolManagement.Core.Contracts
{
    public interface INotificationManager
    {
        void InitNotification(ContentControl container, NotificationPosition position, int maxItems);

        void ShowSuccess(string message, TimeSpan? timeout = null, Action? onClick = null, Action? onClose = null);

        void ShowError(string message, TimeSpan? timeout = null, Action? onClick = null, Action? onClose = null);

        void ShowInfor(string message, TimeSpan? timeout = null, Action? onClick = null, Action? onClose = null);

        void ShowWarning(string message, TimeSpan? timeout = null, Action? onClick = null, Action? onClose = null);

        void ShowSimpleText(string message, TimeSpan? timeout = null, Action? onClick = null, Action? onClose = null);
    }
}