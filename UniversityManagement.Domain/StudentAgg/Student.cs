using System.Collections.Generic;
using UniversityManagement.Domain.ReportCardAgg;

namespace UniversityManagement.Domain.StudentAgg
{
    public class Student 
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string FatherName { get; private set; }
        public string NationalCode { get; private set; }

        //Relation
        public ICollection<ReportCard> ReportCards { get; set; }

        public Student(string name, string fatherName, string nationalCode)
        {
            Name = name;
            FatherName = fatherName;
            NationalCode = nationalCode;
        }

    }
}
