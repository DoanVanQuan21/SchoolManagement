using Prism.Events;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.Core.Events
{
    public class LoginSuccessEvent : PubSubEvent<bool>
    {
    }

    public class LogoutSuccessEvent : PubSubEvent
    { }

    public class UpdateGradeSheetEvent : PubSubEvent<GradeSheet>
    { }

    public class RequestRefreshPageEvent : PubSubEvent
    {
    }
}