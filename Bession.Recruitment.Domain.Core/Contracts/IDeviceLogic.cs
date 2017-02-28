using Bession.Recruitment.Domain.Entities.Device;

namespace Bession.Recruitment.Domain.Core.Contracts
{
    public interface IDeviceLogic
    {
        Device GetBySku(string sku);
    }
}
