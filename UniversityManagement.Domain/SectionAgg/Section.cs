using FrameWorkUni.FW.Domain;
using System.Collections.Generic;
using UniversityManagement.Domain.ReportCardAgg;
using UniversityManagement.Domain.StudentAgg;

namespace UniversityManagement.Domain.SectionAgg
{
    public class Section 
    {
        public long Id { get; private set; }
        public string NameDegree { get; private set; }
        public string Description { get; private set; }

        //Relation
        public ICollection<ReportCard> ReportCards { get; set; }

        public Section(string nameDegree, string description)
        {
            NameDegree = nameDegree;
            Description = description;
        }
    }
}
