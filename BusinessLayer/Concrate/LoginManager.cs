using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Concrate
{
    public class LoginManager : ILoginService
    {
        IRepository<Admin> _login;

        public LoginManager(IRepository<Admin> login)
        {
            _login = login;
        }

        public Admin GetAdmin(Admin admin)
        {
            return _login.Get(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
        }

        public Admin GetAdminForRole(string userName)
        {
            return _login.Get(x => x.AdminUserName == userName);
        }

       
    }
}