


using Common.Helper;
using System.Configuration;
using System.Reflection;

namespace Common.BaseExample
{
    public class BaseDALFactory
    {
        private static readonly string _AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public static T CreateDAL<T>()
        {
            string _CacheKey = typeof(T).Name;
            T obj = (T)CacheHelper.GetCache(_CacheKey);//从缓存读取
            if (obj == null)
            {
                obj = (T)Assembly.Load(_AssemblyPath).CreateInstance(_AssemblyPath + "." +_CacheKey.Substring(1)); //反射创建 IDAL下的DAL
                CacheHelper.SetCache(_CacheKey, obj);// 写入缓存
            }
            return obj;
        }
    }
}
