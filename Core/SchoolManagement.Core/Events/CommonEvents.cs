using Prism.Events;

namespace SchoolManagement.Core.Events
{
    public class LoginSuccessEvent : PubSubEvent<bool>
    {
    }

    public class LogoutSuccessEvent : PubSubEvent
    { }
}