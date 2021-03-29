namespace NetCoreStudy.Domain
{
    public sealed class SubjectDetail
    {
        public string SubjectId { get; set; }

        public int GradeLevel { get; set; }

        public SubjectDetail(string subjectId, int gradeLevel)
        {
            SubjectId = subjectId;
            GradeLevel = gradeLevel;
        }
    }
}
