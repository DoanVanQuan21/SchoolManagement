using Prism.Mvvm;
using System.ComponentModel;

namespace SchoolManagement.Core.Models.Common
{
    public class ServerInfor : BindableBase
    {
        private string? name;
        private string? connectionString = "Data Source=ADMIN;Initial Catalog=SchoolManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private string? state;

        [DisplayName("Tên server")]
        public string? Name
        { get => name; set { SetProperty(ref name, value); } }

        [DisplayName("Chuỗi kết nối")]
        public string? ConnectionString
        { get => connectionString; set { SetProperty(ref connectionString, value); } }

        [Browsable(false)]
        public string? State
        { get => state; set { SetProperty(ref state, value); } }

        [Browsable(false)]
        public Guid ID { get; set; }

        public ServerInfor()
        {
            ID = Guid.NewGuid();
        }
    }
}