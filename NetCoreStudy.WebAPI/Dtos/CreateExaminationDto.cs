using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStudy.WebAPI.Dtos
{
    public class CreateExaminationDto
    {
        [Required]
        public string SubjectId { get; set; }

        public string Name { get; set; }

        public decimal TotalScore { get; set; }

        public decimal PassLine { get; set; }

        public DateTime ExamTime { get; set; }
    }
}
