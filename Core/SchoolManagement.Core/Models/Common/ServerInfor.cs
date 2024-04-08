using Prism.Mvvm;
using System.ComponentModel;

namespace SchoolManagement.Core.Models.Common
{
    public class ServerInfor : BindableBase
    {
        private string? serverName;
        private string? state;
        private string user;
        private string password;
        private string ipV4Address;

        [DisplayName("Tên server")]
        public string? ServerName
        { get => serverName; set { SetProperty(ref serverName, value); } }

        [Browsable(false)]
        public string? ConnectionString => $"Data Source={ServerName};User ID={User};Password={password};Connect Timeout=5;Initial Catalog=SchoolManagement;TrustServerCertificate=True;";

        [Browsable(false)]
        public string? State
        { get => state; set { SetProperty(ref state, value); } }

        [DisplayName("Tên tài khoản")]
        [Browsable(false)]
        public string User
        { get => user; set { SetProperty(ref user, value); } }

        [DisplayName("Mật khẩu")]
        public string Password
        { get => password; set { SetProperty(ref password, value); } }

        public string IpV4Address
        { get => ipV4Address; set { SetProperty(ref ipV4Address, value); } }

        [Browsable(false)]
        public Guid ID { get; set; }

        public ServerInfor()
        {
            ID = Guid.NewGuid();
        }
    }
}