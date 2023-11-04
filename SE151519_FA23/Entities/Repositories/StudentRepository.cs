using Entities.IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(Prn231Su23StudentGroupDbContext context) : base(context)
        {
        }

        public override Student GetById(int id)
        { 
            return _context.Set<Student>().Where(x=> x.Id==id).FirstOrDefault();
        }
    }
}
