using System.Collections.Generic;

namespace UniversityManagement.Application.Conteract.StudentCo
{
    public interface IStudentApplication
    {
        List<StudentDto> GetAll();
        StudentDto GetByID(long id);

    }
}
