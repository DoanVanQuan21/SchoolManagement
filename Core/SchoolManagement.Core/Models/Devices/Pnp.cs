using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Contracts;
using Prism.Mvvm;

namespace SchoolManagement.Core.Models.Devices
{
    public abstract class Pnp : BindableBase, IDevice
    {
        private string? pnpID;
        private string? pnpClass;
        private string? devName;
        private string? typeName;
        private DeviceType deviceType;
        private string? description;
        private ConnectionStatus connectionStatus;
        private bool isMonitor;

        public Guid ID { get; set; }

        public string? PnpID
        {
            get { return pnpID; }
            set { SetProperty(ref pnpID, value); }
        }

        public string? PnpClass
        {
            get { return pnpClass; }
            set { SetProperty(ref pnpClass, value); }
        }

        public string? DevName
        { get => devName; set { SetProperty(ref devName, value); } }

        public string? TypeName
        { get => typeName; set { SetProperty(ref typeName, value); } }


        public DeviceType DeviceType
        {
            get { return deviceType; }
            set { SetProperty(ref deviceType, value); }
        }

        public string? Description
        { get => description; set { SetProperty(ref description, value); } }

        public ConnectionStatus ConnectionStatus
        { get => connectionStatus; set { SetProperty(ref connectionStatus, value); } }

        public bool IsMonitor
        { get => isMonitor; set { SetProperty(ref isMonitor, value); } }

        public abstract void CleanUp();

        public abstract void Close();

        public abstract void Create();

        public abstract void Dispose();

        public abstract void Init();

        public abstract void Open();
    }
}