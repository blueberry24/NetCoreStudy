using System.ComponentModel.DataAnnotations;

namespace NetCoreStudy.WebAPI.Dtos
{
    public class CreateSubjectDto
    {
        [Required(ErrorMessage = "课程名称必填")]
        [Display(Name = "课程名称")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "描述信息必填")]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [Required(ErrorMessage ="学年信息必填")]
        [Display(Name="学年")]
        public int GradeLevel { get; set; }
    }
}
