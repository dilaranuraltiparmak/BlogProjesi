using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfWriterRepository : GenericRepository<Writer>,IWriterDal
    {
        public List<Writer> GetListAll(Writer p)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetListAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}
