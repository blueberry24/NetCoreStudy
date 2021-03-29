using System;

namespace NetCoreStudy.WebAPI.Dtos
{
    public class GetSubjectExaminationsDto
    {
        public string SubjectId { get; set; }

        public string SubjectName { get; set; }

        public string ExaminationId { get; set; }

        public string ExamName { get; set; }

        public DateTime ExamTime { get; set; }
    }
}
