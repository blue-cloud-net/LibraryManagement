using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Entity;
using IDAL;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public abstract partial class Program
    {
        public IBaseDAL<BookInfo> Dal { get; set; }

        [Test]
        public static void Main(string[] args)
        {
            IBaseDAL<BookInfo> Dal = Container.Resolve<IBookInfoDAL>();
            BookInfo bookInfo = new BookInfo()
            {
                BookId = 1,
                BookName = "piaoliuji",
                AuthorName = "zhangsan",
                BookTypeId = 1
            };
            Dal.Add(bookInfo);
        }
    }
}
