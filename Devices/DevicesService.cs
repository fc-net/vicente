using System.Collections.Generic;
using Beesion.Recruitment.SeniorTest.Services;
using System;
using Bession.Recruitment.Domain.Core.Repositories;
using Bession.Recruitment.Application.Core.DTOs;
using System.Linq;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    [BusinessService]
    public class DevicesService : IDevicesService
    {
        private readonly IDevicesRepository _devicesRepository;
        public DevicesService(IDevicesRepository devicesRepository)
        {
            if (devicesRepository == null)
                throw new ArgumentNullException();
            _devicesRepository = devicesRepository;
        }

        [BusinessOperation]
        public IList<DeviceDto> GetAll()
        {
            var devices = _devicesRepository.GetAll().ToList();
            return MapperDevices.GetDeviceDto(devices);
        }
    }
}