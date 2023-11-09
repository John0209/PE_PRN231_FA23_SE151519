using BusinessLogic.Token.IService;
using Entities.IRepositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class StudentGroupService:IStudentGroupService
    {
        IUnitRepository _unit;

        public StudentGroupService(IUnitRepository unit)
        {
            _unit = unit;
        }

        public List<StudentGroup> GetAll()
        {
            return _unit.StudentGroupRepository.GetAll();
        }
    }
}
