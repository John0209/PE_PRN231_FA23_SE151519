using BusinessLogic.IService;
using Entities.IRepositories;
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
    }
}
