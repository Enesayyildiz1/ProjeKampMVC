using DataAccessLayer.Abstract;
using DevFramework.Core.DataAccess.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.Concrete
{
    public class HeadingDal : EfEntityRepositoryBase<Heading, ProjeContext>, IHeadingDal
    {
        Category category = new Category();

       

        public List<Heading> GetHeadingClearly()
        {
            using (ProjeContext db =new ProjeContext())
            {
                var liste = db.Headings.Include(x => x.Category).Include(a=>a.Writer).ToList();
                return liste;
            }
        }
        public List<Heading> GetHeadingClearlyByWriterId(int id)
        {
            using (ProjeContext db = new ProjeContext())
            {
                var liste = db.Headings.Include(x => x.Category).Include(a => a.Writer).Where(x => x.WriterId == id).ToList();
                return liste;
            }
        }
    }
}
