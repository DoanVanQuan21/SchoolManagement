using Avalonia.Controls;
using Avalonia.Controls.Notifications;

namespace SchoolManagement.Core.Contracts
{
    public interface INotificationManager
    {
        void InitNotification(ContentControl container, NotificationPosition position, int maxItems);

        void ShowSuccess(string message, int timeout = 3, Action? onClick = null, Action? onClose = null);

        void ShowError(string message, int timeout = 3, Action? onClick = null, Action? onClose = null);

        void ShowInfor(string message, int timeout = 3, Action? onClick = null, Action? onClose = null);

        void ShowWarning(string message, int timeout = 3, Action? onClick = null, Action? onClose = null);

        void ShowSimpleText(string message, int timeout = 3, Action? onClick = null, Action? onClose = null);
    }
}