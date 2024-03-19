using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Contracts
{
    public interface IDeviceManager<TDevice, TConfig>
    {
        ObservableCollection<TDevice>? Devices { get; set; }

        void Create(params object[] objs);
        TDevice? GetDevice(string name);
    }
}