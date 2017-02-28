using Bession.Recruitment.Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bession.Recruitment.Domain.Entities.Device;
using Bession.Recruitment.Domain.Core.Repositories;

namespace Bession.Recruitment.Domain.Devices
{
    public class DeviceLogic : IDeviceLogic
    {
        private readonly IDevicesRepository _deviceRepository;
        public DeviceLogic(IDevicesRepository deviceRepository)
        {
            if (deviceRepository == null)
                throw new ArgumentNullException();
            _deviceRepository = deviceRepository;
        }

        public Device GetBySku(string sku)
        {
            return _deviceRepository.GetAll().FirstOrDefault(s => string.Compare(sku, s.Sku) == 0);
        }
    }
}
