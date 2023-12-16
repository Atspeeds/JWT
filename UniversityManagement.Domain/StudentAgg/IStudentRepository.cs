using System.Collections.Generic;
using UniversityManagement.Application.Conteract.StudentCo;

namespace UniversityManagement.Domain.StudentAgg
{
    public interface IStudentRepository
    {
        IList<StudentDto> Get();
        StudentDto Get(long id);
        
    }
}
