using Bession.Recruitment.Application.Core.DTOs;
using System.Collections.Generic;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    public interface IDevicesService
    {
        IList<DeviceDto> GetAll();
    }
}