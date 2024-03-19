using Prism.Mvvm;

namespace SchoolManagement.Core.Models
{
    public class User : BindableBase
    {
        private string name;
        private string email;
        private string phone;
        private string username;
        private string password;
        private string emailConfirmed;

        public int Id { get; set; }
        public string Name
        { get => name; set { SetProperty(ref name, value); } }
        public string Email
        { get => email; set { SetProperty(ref email, value); } }
        public string Phone
        { get => phone; set { SetProperty(ref phone, value); } }
        public string Username
        { get => username; set { SetProperty(ref username, value); } }
        public string Password
        { get => password; set { SetProperty(ref password, value); } }
        public string EmailConfirmed
        { get => emailConfirmed; set { SetProperty(ref emailConfirmed, value); } }
    }
}