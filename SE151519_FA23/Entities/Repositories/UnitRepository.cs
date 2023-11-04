using Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        public IStudentRepository StudentRepository {get;}

        public IStudentGroupRepository StudentGroupRepository { get; }

        public IUserRoleRepository UserRoleRepository { get; }

        public UnitRepository(IStudentRepository studentRepository, IStudentGroupRepository studentGroupRepository, IUserRoleRepository userRoleRepository)
        {
            StudentRepository = studentRepository;
            StudentGroupRepository = studentGroupRepository;
            UserRoleRepository = userRoleRepository;
        }
    }
}
