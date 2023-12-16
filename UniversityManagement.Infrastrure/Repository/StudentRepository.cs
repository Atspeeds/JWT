using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UniversityManagement.Application.Conteract.StudentCo;
using UniversityManagement.Domain.StudentAgg;

namespace UniversityManagement.Infrastrure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniManagementContext _context;

        public StudentRepository(UniManagementContext context)
        {
            _context = context;
        }




        public IList<StudentDto> Get() => _context.Students
           .Select(x => new StudentDto
           {
               Id = x.Id,
               Name = x.Name,
               FatherName = x.FatherName,
               NationalCode = x.NationalCode,

           }).OrderBy(x => x.Id).ToList();



        public StudentDto Get(long id) => _context.Students
              .Select(x => new StudentDto
              {
                  Id = x.Id,
                  Name = x.Name,
                  FatherName = x.FatherName,
                  NationalCode = x.NationalCode,

              })
             .FirstOrDefault(x => x.Id == id);



    }
}
