using FrameWorkUni.FW.Domain;
using UniversityManagement.Domain.SectionAgg;
using UniversityManagement.Domain.StudentAgg;

namespace UniversityManagement.Domain.ReportCardAgg
{
    public class ReportCard
    {
        public long Id { get; private set; }
        public char FinalScore { get; private set; }
        public bool Accepted { get; private set; }
        public long StudentID { get; private set; }
        public long SectionID { get; private set; }
        //Relation
        public Student Student { get; private set; }
        public Section Section { get; private set; }

        public ReportCard(char finalScore, bool accepted)
        {
            FinalScore = finalScore;
            Accepted = accepted;
        }

    }
}
