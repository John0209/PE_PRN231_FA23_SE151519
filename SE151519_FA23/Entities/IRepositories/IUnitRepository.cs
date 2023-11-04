using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IRepositories
{
    public interface IUnitRepository
    {
        IStudentRepository StudentRepository { get; }
        IStudentGroupRepository StudentGroupRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
    }
}
