using BusinessLogic.IService;
using Entities.IRepositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class StudentService : IStudentService
    {
        IUnitRepository _unit;

        public StudentService(IUnitRepository unit)
        {
            _unit = unit;
        }

        public bool AddStudent(Student student)
        {
            var m_add= new Student();
            m_add.FullName = student.FullName;
            m_add.DateOfBirth = student.DateOfBirth;
            m_add.Email = student.Email;
            m_add.GroupId = student.GroupId;
            _unit.StudentRepository.Add(m_add);
            var result = _unit.StudentRepository.Save();
            if (result > 0) return true;
            return false;
        }

        public bool DeleteStudent(int id)
        {
            var student= GetStudentById(id);
            if (student != null)
            {
            _unit.StudentRepository.Delete(student);
            var result = _unit.StudentRepository.Save();
            if (result > 0) return true;
            }
            return false;
        }

        public List<Student> GetAll()
        {
            return _unit.StudentRepository.GetAll();
        }

        public Student GetStudentById(int id)
        {
            return _unit.StudentRepository.GetById(id);
        }

        public List<Student?> GetStudentByParameter(int groupId, DateTime minBirthday, DateTime maxBirthday)
        {
            var student=GetAll();
            var result = (from s in student where s.GroupId == groupId && s.DateOfBirth > minBirthday && s.DateOfBirth < maxBirthday select s).ToList();
            if (result.Any()) return result;
            return null;
        }

        public bool UpdateStudent(Student student)
        {
            var m_update = GetStudentById(student.Id);
            if (m_update != null)
            {
            m_update.FullName = student.FullName;
            m_update.DateOfBirth = student.DateOfBirth;
            m_update.Email = student.Email;
            m_update.GroupId = student.GroupId;
            _unit.StudentRepository.Update(student);
            var result = _unit.StudentRepository.Save();
            if (result > 0) return true;
            }
            return false;
        }
    }
}
