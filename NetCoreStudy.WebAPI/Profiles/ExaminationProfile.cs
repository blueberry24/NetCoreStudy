using AutoMapper;
using NetCoreStudy.Domain;
using NetCoreStudy.WebAPI.Dtos;

namespace NetCoreStudy.WebAPI.Profiles
{
    public class ExaminationProfile : Profile
    {
        public ExaminationProfile()
        {
            CreateMap<CreateExaminationDto, SubjectExamination>().ConvertUsing(s => new SubjectExamination(s.Name, s.PassLine, s.TotalScore, s.ExamTime, 1, 1, s.SubjectId));
        }
    }
}
