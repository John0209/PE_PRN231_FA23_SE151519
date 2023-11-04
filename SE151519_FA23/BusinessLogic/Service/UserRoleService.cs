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
    public class UserRoleService:IUserRoleService
    {
        IUnitRepository _unit;

        public UserRoleService(IUnitRepository unit)
        {
            _unit = unit;
        }

        public UserRole? Login(string username, string password)
        {
            var user = GetAll();

            if (user != null)
            {
                var result = (from u in user where u.Username==username && u.Passphrase==password select u).FirstOrDefault();
                if(result != null) return result;
            }
            return null;
        }
        private List<UserRole> GetAll()
        {
            return _unit.UserRoleRepository.GetAll();
        }
    }
}
