using System.Collections.Generic;
using System.Linq;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    public class DevicesRepository
    {
        private static readonly List<Device> items = new List<Device>
        {
            new Device{
                Brand="Nokia",Model="Lumia 822 - Black",Sku="79032468236482",
                Specifications = new List<DeviceSpecification>
                {
                    new DeviceSpecification{Feature = "Windows Phone 8 Platform",Comments = ""},
                    new DeviceSpecification{Feature = "8MP Rear Camera",Comments = ""},
                    new DeviceSpecification{Feature = "1.2MP Front-Facing Camera",Comments = ""},
                    new DeviceSpecification{Feature = "Built in XBOX Live",Comments = ""},
                    new DeviceSpecification{Feature = "Mobile Hotspot Capable",Comments = "Available only on 4G LTE network"},
                    new DeviceSpecification{Feature = "4.3'' WVGA Touchscreen",Comments = ""},
                }
            },
            new Device{
                Brand="HTC",Model="8XT",Sku="896352523425",
                Specifications = new List<DeviceSpecification>
                {
                    new DeviceSpecification{Feature = "Microsoft Windows Phone 8 operating system",Comments = ""},
                    new DeviceSpecification{Feature = "Dual-core 1.4 GHz Krait",Comments = ""},
                    new DeviceSpecification{Feature = "Multiple sensors: Accelerometer, proximity, compass",Comments = ""},
                    new DeviceSpecification{Feature = "The best sound quality with BoomSound™",Comments = "Dual front-facing audio speakers"},
                }
            },
            new Device{
                Brand="Kyocera",Model="Hydro Edge",Sku="563456780987",
                Specifications = new List<DeviceSpecification>
                {
                    new DeviceSpecification{Feature = "Android 4.1 (Jelly Bean)",Comments = ""},
                    new DeviceSpecification{Feature = "Certified dust-proof and waterproof",Comments = ""},
                    new DeviceSpecification{Feature = "1 GHz Dual-core Qualcomm Snapdragon® Processor",Comments = ""},
                    new DeviceSpecification{Feature = "5 MP Camera w/ Flash and Camcorder",Comments = ""},
                    new DeviceSpecification{Feature = "Google Mobile Services",Comments = "Play™, Search™, Maps™"},
                    new DeviceSpecification{Feature = "Stereo Bluetooth",Comments = "Accesories not included"},
                    new DeviceSpecification{Feature = "Wi-Fi Hotspot Capabilites",Comments = ""},
                }
            },
            new Device{
                Brand="LG",Model="Lucid 2",Sku="75698638475673",
                Specifications = new List<DeviceSpecification>
                {
                    new DeviceSpecification{Feature = "Bluetooth",Comments = "Bluetooth v3.0 headset,hands]free, object push, advanced audio distribution"},
                    new DeviceSpecification{Feature = "GPS",Comments = "A-GPS"},
                    new DeviceSpecification{Feature = "Scratch resistant Corning® Gorilla™ Glass 2",Comments = ""},
                    new DeviceSpecification{Feature = "Android 4.1.2 OS (Jelly Bean)",Comments = ""},
                }
            },
        };

        public static IList<Device> GetAll()
        {
            return items;
        }

        public static Device GetBySku(string sku)
        {
            return items.FirstOrDefault(s => string.Compare(sku, s.Sku) == 0);
        }
    }
}