using Bession.Recruitment.Application.Core.DTOs;
using Bession.Recruitment.Domain.Entities.Accesory;
using System.Collections.Generic;

namespace Bession.Recruitment.Application.Accesories
{
    public static class MapperAccesory
    {
        internal static List<AccesoryDto> GetAccesoryDto(IList<Accesory> listAccesory)
        {
            var accesoriesDto = new List<AccesoryDto>();

            foreach (var currentEntity in listAccesory)
            {
                accesoriesDto.Add(ToDto(currentEntity));
            }

            return accesoriesDto;
        }

        internal static AccesoryDto ToDto(Accesory accesoryEntity)
        {
            AccesoryDto dto = new AccesoryDto()
            {
                Brand = accesoryEntity.Brand,
                Description = accesoryEntity.Description,
                PartNumber = accesoryEntity.PartNumber
            };

            return dto;
        }
    }
}
