using NUnit.Framework;
using Common.BaseExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Entity;

namespace Common.BaseExample.Tests
{
    [TestFixture()]
    public class BaseDALFactoryTests
    {
        [Test()]
        public void CreateDALTest()
        {
            try
            {
                IBookInfoDAL _IBookInfoDAL = BaseDALFactory.CreateDAL<IBookInfoDAL>();
                BookInfo _BookInfo = new BookInfo()
                {
                    BookId = 1,
                    BookName = "黑",
                    AuthorName = "张三",
                    BookTypeId = 1
                };
                _IBookInfoDAL.Add(_BookInfo);
                _IBookInfoDAL.SaveChanges();
            }
            catch (Exception)
            {
                throw;
                Assert.Fail();
            }
            finally
            {
                Assert.IsFalse(false);
            }
        }
    }
}