using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager
    {
        IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public void Add(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(int id)
        {
            return _appUserDal.GetByID(id);
        }
        public List<AppUser> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser t)
        {
            _appUserDal.Update(t);
        }
    }
}
