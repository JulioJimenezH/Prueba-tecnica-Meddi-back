using AutoMapper;
using Prueba_tecnica_Meddi_back.Meddi.Catalogos;
using Prueba_tecnica_Meddi_back.Meddi.Dtos;

namespace Prueba_tecnica_Meddi_back.Meddi.Api.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Mapeo de entidad (DB) a DTO (salida a front)
            CreateMap<TaskItem, TaskItemDto>();
            //Mapeo de DTO (entrada del front) a entidad (DB)
            CreateMap<CreateTaskDto, TaskItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src=>DateTime.UtcNow));

        }

    }
}
