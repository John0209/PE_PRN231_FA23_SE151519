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
        public bool Add(Student student);
        public bool Update(Student student);
        public bool Delete(int id);
        public Student GetById(int id);
        public List<Student> GetStudentByParameter(int groupId, DateTime minBirthday, DateTime maxBirthday);
    }
}
