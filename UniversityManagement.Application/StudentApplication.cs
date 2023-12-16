using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Application.Conteract.StudentCo;
using UniversityManagement.Domain.StudentAgg;

namespace UniversityManagement.Application
{
    public class StudentApplication : IStudentApplication
    {
        private readonly IStudentRepository _studentRepository;

        public StudentApplication(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<StudentDto> GetAll()
        {
            return _studentRepository.Get().ToList();
        }

        public StudentDto GetByID(long id)
        {
            return _studentRepository.Get(id);
        }


    }
}
