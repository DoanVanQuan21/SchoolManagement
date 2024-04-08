using SchoolManagement.Core.Models.Common;

namespace SchoolManagement.Core.Contracts
{
    public interface IDatabaseInfoProvider
    {
        ServerInfor ServerInfor { get; }
    }
}