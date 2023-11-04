using Entities.IRepositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class StudentGroupRepository : GenericRepository<StudentGroup>, IStudentGroupRepository
    {
        public StudentGroupRepository(Prn231Su23StudentGroupDbContext context) : base(context)
        {
        }
    }
}
