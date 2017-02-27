using System.Collections.Generic;
using Beesion.Recruitment.SeniorTest.Services;
using System;
using Beesion.Recruitment.Application;
using Bession.Recruitment.Application;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    [BusinessService]
    public class DevicesService
    {
        private readonly IDevice _device;
        public DevicesService(IDevice device)
        {
            if (device == null)
                throw new ArgumentNullException();
            _device = device;
        }

        [BusinessOperation]
        public IList<DeviceDto> GetAll()
        {
            var devices = _device.GetAll();
            return GetDeviceDto(devices);
        }

        private IList<DeviceDto> GetDeviceDto(IList<Device> devices)
        {
            var result = new List<DeviceDto>();

            foreach (var dev in devices)
            {
                result.Add(new DeviceDto
                {
                    Model = dev.Model,
                    Brand = dev.Brand,
                    Description = dev.Description,
                    Sku = dev.Sku
                });
            }

            return result;
        }
    }
}