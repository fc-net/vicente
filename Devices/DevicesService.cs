using System.Collections.Generic;
using Beesion.Recruitment.SeniorTest.Services;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    [BusinessService]
    public class DevicesService
    {
        [BusinessOperation]
        public IList<Device> GetAll()
        {
            return DevicesRepository.GetAll();
        }
    }
}