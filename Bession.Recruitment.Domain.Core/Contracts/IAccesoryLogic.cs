using Bession.Recruitment.Domain.Entities.Accesory;

namespace Bession.Recruitment.Domain.Core.Contracts
{
    public interface IAccesoryLogic
    {
        Accesory GetByPartNumber(string partNumber);
    }
}
