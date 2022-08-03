using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWriterDal:IGenericDal<Writer>
    {
#pragma warning disable CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik
        void Insert(Writer writer);
#pragma warning restore CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik
        List<Writer> GetListAll(int id);
    
    }
}
