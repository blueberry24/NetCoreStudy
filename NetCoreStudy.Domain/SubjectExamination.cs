using NetCoreStudy.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreStudy.Domain
{
    public class SubjectExamination : Entity<string>, IAggregateRoot
    {
        public override string Id { get; protected set; }
        /// <summary>
        /// 考试名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 及格线
        /// </summary>
        public decimal PassLine { get; private set; }

        /// <summary>
        /// 总分
        /// </summary>
        public decimal TotalScore { get; private set; }

        /// <summary>
        /// 考试时间
        /// </summary>
        public DateTime ExamTime { get; private set; }

        /// <summary>
        /// 允许重考的次数
        /// </summary>
        public int ReExamineTimes { get; private set; }

        /// <summary>
        /// 监考员数量
        /// </summary>
        public int InvigilatorCount { get; private set; }

        /// <summary>
        /// 科目
        /// </summary>
        public Subject Subject { get; private set; }

        public string SubjectId { get; private set; }

        public SubjectExamination()
        {

        }

        public SubjectExamination(string name, decimal passline, decimal totalscore, DateTime examtime, int reexaminetimes, int invigilatorcount, string subjectId)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            PassLine = passline;
            TotalScore = totalscore;
            ExamTime = examtime;
            ReExamineTimes = reexaminetimes;
            InvigilatorCount = invigilatorcount;
            SubjectId = subjectId;
        }
    }
}
