using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models.Common;
using System.Diagnostics;
using System.Net;

namespace SchoolManagement.Core.Services
{
    public class DatabaseInfoProvider : IDatabaseInfoProvider
    {
        public ServerInfor ServerInfor { get; set; }

        public DatabaseInfoProvider()
        {
            InitServerInfor();
        }

        private void InitServerInfor()
        {
            if (ServerInfor != null)
            {
                return;
            }
            var ipV4Address = GetIpV4Address();
            if (string.IsNullOrEmpty(ipV4Address))
            {
                Debug.WriteLine("Can not get IPV4 ADDRESS");
                return;
            }
            ServerInfor = new()
            {
                ServerName = "192.168.1.103",
                User = "schoolmanagement",
                Password = "123",
            };
        }

        private string GetHostName()
        {
            return Dns.GetHostName();
        }

        public string GetIpV4Address()
        {
            var hostname = GetHostName();
            var addresses = Dns.GetHostByName(hostname).AddressList;
            if (addresses == null)
            {
                return string.Empty;
            }
            var ipV4 = "";
            if (addresses.Length <= 0)
            {
                return string.Empty;
            }
            var lastIndex = addresses.Length - 1;
            return addresses[lastIndex].ToString();
        }
    }
}