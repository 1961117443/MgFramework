using Mg.Untility;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace Mg.Core.IOC
{
    /// <summary>
    /// 依赖注入工厂
    /// </summary>
    public class DIFactory
    { 

        private static readonly object _DILock = new object();
        private static Dictionary<string, IUnityContainer> _UnityContainerDictionary = new Dictionary<string, IUnityContainer>();

        /// <summary>
        /// 根据containerName获取指定的container
        /// </summary>
        /// <param name="containerName">配置的containerName，默认为defaultContainer</param>
        /// <returns></returns>
        protected static IUnityContainer GetContainer(string containerName = "")
        {
            if (containerName.IsEmpty())
            {
                containerName = ConstantSetting.UnityContainerName;
            }
            if (!_UnityContainerDictionary.ContainsKey(containerName))
            {
                lock (_DILock)
                {
                    if (!_UnityContainerDictionary.ContainsKey(containerName))
                    {
                        //配置UnityContainer
                        IUnityContainer container = new UnityContainer();

                        //读取配置文件
                        //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                        //fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + ConstantSetting.UnityPath);
                        //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                        //UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                        //configSection.Configure(container, containerName);

                        _UnityContainerDictionary.Add(containerName, container);
                    }
                }
            }
            return _UnityContainerDictionary[containerName];
        }

        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IUnityContainer Instance
        {
            get
            {
                return GetContainer();
            }
        }
        /// <summary>
        /// 获取实例对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>()
        { 
            return Instance.Resolve<T>();
        }
        /// <summary>
        /// 获取实例对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>(params ResolverOverride[] resolverOverrides)
        {
            return Instance.Resolve<T>(resolverOverrides);
        }

        /// <summary>
        /// 根据类型获取实例对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetService(Type type)
        { 
            return Instance.Resolve(type);
        }
    }
}
