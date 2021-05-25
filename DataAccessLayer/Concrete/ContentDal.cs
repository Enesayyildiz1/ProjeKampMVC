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
    public class ContentDal : EfEntityRepositoryBase<Content, ProjeContext>, IContentDal
    {
        Writer heading = new Writer();
        public List<Content> GetContentsByHeading(int headingId)
        {
            using (ProjeContext db = new ProjeContext())
            {
                var liste = db.Contents.Include(x => x.Writer).Where(x=>x.HeadingId==headingId).ToList();
                return liste;
            }
        }
    }
}
