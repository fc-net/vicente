using Bession.Recruitment.Domain.Core.Repositories;
using Bession.Recruitment.Domain.Entities.Accesory;
using System.Collections.Generic;
using System.Linq;

namespace Bession.Recruitment.Data.Repositories
{
    public class AccesoryRepository : RepositoryBase<Accesory>, IAccesoryRepository
    {
        private readonly List<Accesory> items = new List<Accesory>()
        {
            new Accesory{AccesoryId = 1,Brand = "HTC", Description = "HD2 Car charger DROID Incredible",PartNumber = "CCHA-HTCINC2"},
            new Accesory{AccesoryId = 1,Brand = "HTC", Description = "Retractable charger DROID Incredible",PartNumber = "RCHA-HTCINC2"},
            new Accesory{AccesoryId = 1,Brand = "HTC", Description = "Universal USB Charger Kit With 6 Phone Connectors",PartNumber = "CCHA-UNUSB5C"},
            new Accesory{AccesoryId = 1,Brand = "Samsung", Description = "Clear Silicone Skin Case For Samsung a237",PartNumber = "CASE-SAMA237CON"},
            new Accesory{AccesoryId = 1,Brand = "Apple", Description = "Black Silicone Skin Case For Apple iPhone 3G, iPhone 3G S",PartNumber = "CASE-IPHO3SKBCKS"}
        };

        override public IQueryable<Accesory> GetAll()
        {
            return items.AsQueryable();
        }
    }
}
