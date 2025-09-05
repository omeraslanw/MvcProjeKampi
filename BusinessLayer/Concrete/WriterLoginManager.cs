using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterLoginDal _writerLoginDal;

        public WriterLoginManager(IWriterLoginDal writerLoginDal)
        {
            _writerLoginDal = writerLoginDal;
        }

        public Writer LoginWriter(string username, string password)
        {
            return _writerLoginDal.Get(x => x.WriterMail == username && x.WriterPassword == password);
        }
    }
}
