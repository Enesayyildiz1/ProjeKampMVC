﻿
using DevFramework.Core.DataAccess;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IHeadingDal : IEntityRepository<Heading>
    {
         List<Heading> GetHeadingClearly();
        List<Heading> GetHeadingClearlyByWriterId(int id);
    }
}
