using Mg.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Untility
{
    public static partial class MangoGreenExtensions
    {
        #region 扩展 Type
        /// <summary>
        /// 类型转换--位置ExtendMethod.cs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        public static T FromType<T, TK>(TK text)
        {
            try
            {
                return (T)Convert.ChangeType(text, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }
        public static MethodInfo GetGenericMethod(this Type targetType, string name, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance, params Type[] parameterTypes)
        {
            var methods = targetType.GetMethods(flags).Where(w => w.Name == name && w.IsGenericMethod);
            foreach (MethodInfo method in methods)
            {
                var parameters = method.GetParameters();
                if ((parameters != null && parameterTypes != null) && (parameters.Length != parameterTypes.Length))
                {
                    continue;
                }
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType != parameterTypes[i])
                    {
                        break;
                    }
                }
                return method;
            }
            return null;
        }

        public static MethodInfo GetGenericMethod(this Type targetType, MethodBase methodBase, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
        {
            var methods = targetType.GetMethods(flags).Where(w => w.Name == methodBase.Name && w.IsGenericMethod);
            foreach (MethodInfo method in methods)
            {
                var parameters = method.GetParameters();
                var targetParameters = methodBase.GetParameters();
                if (parameters.Length != methodBase.GetParameters().Length)
                {
                    continue;
                }
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType != targetParameters[i].ParameterType)
                    {
                        break;
                    }
                }
                return method;
            }
            return null;
        }
        public static MethodInfo GetMethod(this Type targetType, MethodBase methodBase, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
        {
            if (methodBase.IsGenericMethod)
            {
                var methods = targetType.GetMethods(flags).Where(w => w.Name == methodBase.Name && w.IsGenericMethod);
                foreach (MethodInfo method in methods)
                {
                    var parameters = method.GetParameters();
                    var targetParameters = methodBase.GetParameters();
                    if (parameters.Length != methodBase.GetParameters().Length)
                    {
                        continue;
                    }
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (parameters[i].ParameterType != targetParameters[i].ParameterType)
                        {
                            break;
                        }
                    }
                    return method;
                }
            }
            else
            {
                return targetType.GetMethod(methodBase.Name, methodBase.GetParameters().Select(w => w.ParameterType).ToArray());
            }

            return null;
        }
        /// <summary>
        /// 获取类型的FullName
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static string GetRealType(this Type targetType)
        {
            //string name = string.Empty;
            //if (targetType.IsGenericType)
            //{
            //    name = string.Join("_", targetType.GetGenericArguments().Select(w => w.FullName).ToArray());
            //}

            return targetType.FullName;
        }

        /// <summary>
        /// 获取实体属性
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlags"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertiesEx(this Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            return type.GetProperties(bindingFlags);
        }
        

        public static Type GetTypeEx<T>(this Type type)
        { 
            if (type.IsGenericType)
            {
                type = type.MakeGenericType(new Type[] { typeof(T) });
            }
            return type;
        }


        #endregion
    }
}
