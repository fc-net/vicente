using Bession.Recruitment.Application.Core.DTOs;
using Bession.Recruitment.Domain.Entities.Device;
using System.Collections.Generic;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    public static class MapperDevices
    {
        internal static List<DeviceDto> GetDeviceDto(IList<Device> listDevices)
        {
            var devicesDto = new List<DeviceDto>();

            foreach (var currentEntity in listDevices)
            {
                devicesDto.Add(ToDto(currentEntity));
            }

            return devicesDto;
        }

        internal static DeviceDto ToDto(Device deviceEntity)
        {
            DeviceDto dto = new DeviceDto()
            {
                Model = deviceEntity.Model,
                Brand = deviceEntity.Brand,
                Description = deviceEntity.Description,
                Sku = deviceEntity.Sku
            };

            return dto;
        }
    }
}