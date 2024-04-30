﻿using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models.Common;
using System.Diagnostics;
using System.Net;

namespace SchoolManagement.Core.Services
{
    public class DatabaseInfoProvider : IDatabaseInfoProvider
    {
        private readonly IAppManager _appManager;
        private readonly INotificationManager _notificationManager;
        public ServerInfor ServerInfor { get; set; }

        public DatabaseInfoProvider()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            _notificationManager = Ioc.Resolve<INotificationManager>();
            InitServerInfor();
        }

        private void InitServerInfor()
        {
            //TODO
            //MOBILE PLATFORM
            if (_appManager == null)
            {
                _notificationManager.ShowError("Configuration cannot be null!");
                return;
            }
            if (ServerInfor != null)
            {
                _notificationManager.ShowError("Server cannot be null!");
                return;
            }
            if (!OperatingSystem.IsWindows())
            {
                ServerInfor = new()
                {
                    ServerName = " 192.168.1.72",
                    User = "schoolmanagement",
                    Password = "123",
                };
                _appManager.BootSetting.ServerInfor = ServerInfor;
                return;
            }
            if (_appManager.BootSetting.ServerInfor != null)
            {
                if (!OperatingSystem.IsWindows())
                {
                    ServerInfor = new()
                    {
                        ServerName = "192.168.1.77",
                        User = "schoolmanagement",
                        Password = "123",
                    };
                    return;
                }
                ServerInfor = _appManager.BootSetting.ServerInfor;
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
                ServerName = ipV4Address,
                User = "schoolmanagement",
                Password = "123",
            };
            //ServerInfor = new()
            //{
            //    ServerName = "schoolmanagementvy2.database.windows.net",
            //    User = "schoolmanagement",
            //    Password = "admin@123",
            //};
            _appManager.BootSetting.ServerInfor = ServerInfor;
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