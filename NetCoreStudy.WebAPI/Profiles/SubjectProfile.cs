using AutoMapper;
using NetCoreStudy.Domain;
using NetCoreStudy.WebAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStudy.WebAPI.Profiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<CreateSubjectDto, Subject>()
                .ConstructUsing(s => new Subject(s.Name, s.Description));
        }
    }
}
