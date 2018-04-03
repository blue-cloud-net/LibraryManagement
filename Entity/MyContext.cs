namespace Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    #region 数据库表
    public class MyContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MyConext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Entity.MyConext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MyConext”
        //连接字符串。
        public MyContext()
            : base("name=DBConnection")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<BookInfo> Books { get; set; }
        public virtual DbSet<BookDetailInfo> BookInfoes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BorrowInfo> BorrowInfoes { get; set; }
        
    }
    #endregion

    #region 图书相关信息
    /// <summary>
    /// 图书基本信息
    /// </summary>
    public class BookInfo
    {
        /// 图书内部编号
        [Key]
        public int BookId { get; set; }
        // 书名
        public string BookName { get; set; }
        // 作者名
        public string AuthorName { get; set; }
        // 图书类型编号
        public string BookTypeId { get; set; }
    }

    /// <summary>
    /// 图书详细信息
    /// </summary>
    public class BookDetailInfo
    {
        // 图书内部编号
        [Key]
        public int BookId { get; set; }
        // 出版地
        public string PlaceOfPublication { get; set; }
        // 出版者名
        public string CopyrightDescription { get; set; }
        // 书号
        public Int32? ISBN { get; set; }
        // 定价
        public decimal? Price { get; set; }
        // 开本
        public Int32? Folio { get; set; }
        // 印张
        public Int32? Sheet { get; set; }
        // 印数
        public Int32? Impression { get; set; }
        // 版次
        public Int32? Revision { get; set; }
        // 印刷单位
        public Int32? PrintingCompany { get; set; }
    }
    #endregion

    #region 借阅信息
    /// <summary>
    /// 图书借阅信息
    /// </summary>
    public class BorrowInfo
    {
        /// <summary>
        /// 借阅编号
        /// </summary>
        [Key]
        public Int32? BorrowId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 图书编号
        /// </summary>
        public Int32? BookId { get; set; }
        /// <summary>
        /// 借阅时间
        /// </summary>
        public DateTime? BorrowTime { get; set; }
        /// <summary>
        /// 归还时间
        /// </summary>
        public DateTime? ReturnTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Int32? State { get; set; }
    }
    #endregion

    #region 用户相关信息
    public class User
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [Key, Column(Order = 1)]
        public Int32? UserId { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        [Key, Column(Order = 2)]
        public string UserAccount { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public Int32? UserSex { get; set; }
        /// <summary>
        /// 开户时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
    #endregion
}