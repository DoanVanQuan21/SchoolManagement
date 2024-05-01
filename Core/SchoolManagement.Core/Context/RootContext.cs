using Avalonia.Controls.ApplicationLifetimes;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Context
{
    public class RootContext
    {
        public static Dictionary<string, bool> Modules = new();
        public static ObservableCollection<AppMenu> DesktopAppMenus = new();
        public static ObservableCollection<AppMenu> MobileAppMenus = new();
        public static IApplicationLifetime ApplicationLifetime { get; set; }
        public static Stack<Type> PreviewMainViews = new();
        public static User CurrentUser { get; set; } = new User();
        public static bool UpdateCurrentUser(User user)
        {
            if (user == null || RootContext.CurrentUser == null)
            {
                return false;
            }
            RootContext.CurrentUser.FirstName = user.FirstName;
            RootContext.CurrentUser.LastName = user.LastName;
            RootContext.CurrentUser.Gender = user.Gender;
            RootContext.CurrentUser.DateOfBirth = user.DateOfBirth;
            RootContext.CurrentUser.PhoneNumber = user.PhoneNumber;
            RootContext.CurrentUser.Address = user.Address;
            RootContext.CurrentUser.Email = user.Email;
            RootContext.CurrentUser.Image = user.Image;
            RootContext.CurrentUser.Username = user.Username;
            RootContext.CurrentUser.Password = user.Password;
            RootContext.CurrentUser.Role = user.Role;
            RootContext.CurrentUser.ActiveStatus = user.ActiveStatus;
            RootContext.CurrentUser.StartDate = user.StartDate;
            RootContext.CurrentUser.EndDate = user.EndDate;
            return true;
        }
    }
}