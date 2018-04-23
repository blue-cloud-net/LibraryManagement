


using Common.Helper;
using System.Configuration;
using System.Reflection;

namespace Common.BaseExample
{
    public class BaseDALFactory
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public T CreateDAL<T>()
        {
            T obj = CacheHelper.GetCache<T>((new T()).ToString());//从缓存读取
            if (obj == null)
            {
                obj = (T)Assembly.Load(path).CreateInstance(CacheKey + "DAL"); //反射创建 IDAL下的DAL
                CacheHelper.SetCache<T>(CacheKey, obj);// 写入缓存
            }
            return obj;
        }
    }
}
