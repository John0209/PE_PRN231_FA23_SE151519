using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
    public interface IStudentService
    {
        public List<Student> GetAll();
        public bool AddStudent(Student student);
        public bool UpdateStudent(Student student);
        public bool DeleteStudent(int id);
        public Student GetStudentById(int id);
        public List<Student> GetStudentByParameter(int groupId, DateTime minBirthday, DateTime maxBirthday);
    }
}
