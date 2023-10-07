using AutoMapper;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Application.AutoMapper
{
    public class ClassMapper : Profile
    {
        public ClassMapper() 
        {
            CreateMap<Dto.Class, Class>().ReverseMap();
        }

    }
}
