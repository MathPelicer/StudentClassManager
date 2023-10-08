using AutoMapper;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Application.AutoMapper
{
    public class StudentMapper : Profile
    {
        public StudentMapper() 
        {
            CreateMap<Dto.StudentDto, Student>().ReverseMap();
        }
    }
}
