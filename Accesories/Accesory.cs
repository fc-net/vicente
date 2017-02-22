using Beesion.Recruitment.SeniorTest.Common;

namespace Beesion.Recruitment.SeniorTest.Accesories
{
    public class Accesory : IProduct
    {
        public int AccesoryId { get; set; }
        public string Brand { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
    }
}