using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Windows.Input;

namespace SchoolManagement.UI.Controls.DialogControl
{
    public class DialogControl : TemplatedControl
    {
        public static StyledProperty<ICommand> CancelCommandProperty = AvaloniaProperty.Register<DialogControl, ICommand>(nameof(CancelCommand));
        public static StyledProperty<Control> ContentProperty = AvaloniaProperty.Register<DialogControl, Control>(nameof(Content));
        public static StyledProperty<ICommand> OKCommandProperty = AvaloniaProperty.Register<DialogControl, ICommand>(nameof(OKCommand));
        public static StyledProperty<string> TitleProperty = AvaloniaProperty.Register<DialogControl, string>(nameof(Title));
        public ICommand CancelCommand
        {
            get
            {
                return (ICommand)GetValue(CancelCommandProperty);
            }
            set
            {
                SetValue(CancelCommandProperty, value);
            }
        }
        static DialogControl() { }
        public Control Content
        {
            get
            {
                return (Control)GetValue(ContentProperty);
            }
            set
            {
                SetValue(ContentProperty, value);
            }
        }

        public ICommand OKCommand
        {
            get
            {
                return (ICommand)GetValue(OKCommandProperty);
            }
            set
            {
                SetValue(OKCommandProperty, value);
            }
        }

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
    }
}