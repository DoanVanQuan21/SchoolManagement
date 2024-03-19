using Prism.Modularity;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contants;
using SchoolManagement.Core.Context;
using SchoolManagement.Shell.Services.Contracts;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SchoolManagement.Shell.Services
{
    internal class StartUp : IStartUp
    {
        private readonly IModuleCatalog _moduleCatalog;
        private readonly IModuleManager _moduleManager;

        public StartUp()
        {
            _moduleManager = Ioc.Resolve<IModuleManager>();
            _moduleCatalog = Ioc.Resolve<IModuleCatalog>();
        }

        private void LoadModule()
        {
            foreach (var module in _moduleCatalog.Modules)
            {
                try
                {
                    _moduleManager.LoadModule(module.ModuleName);
                }
                catch (Exception e)
                {
                }
                finally
                {
                    //RootContext.Modules[module.ModuleName] = true;
                }
            }
        }

        private static ModuleInfo CreateModuleInfo(Type type, string name)
        {
            string moduleName = name;

            var moduleAttribute = CustomAttributeData.GetCustomAttributes(type).FirstOrDefault(cad => cad.Constructor.DeclaringType.FullName == typeof(ModuleAttribute).FullName);

            if (moduleAttribute != null)
            {
                foreach (CustomAttributeNamedArgument argument in moduleAttribute.NamedArguments)
                {
                    string argumentName = argument.MemberInfo.Name;
                    if (argumentName == "ModuleName")
                    {
                        moduleName = (string)argument.TypedValue.Value;
                        break;
                    }
                }
            }

            ModuleInfo moduleInfo = new(moduleName, type.AssemblyQualifiedName)
            {
                InitializationMode = InitializationMode.OnDemand,
                Ref = type.Assembly.Location,
            };

            return moduleInfo;
        }

        private void AddModule(string dllName)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, dllName);
            if (!File.Exists(filePath))
            {
                return;
            }
            if (RootContext.Modules.ContainsKey(dllName))
            {
                return;
            }
            RootContext.Modules.Add(dllName, false);
            var moduleAssembly = AppDomain.CurrentDomain.GetAssemblies().First(item => item.FullName == typeof(IModule).Assembly.FullName) ?? throw new Exception($"DLL {dllName} is not module");
            var IModuleType = moduleAssembly.GetType(typeof(IModule).FullName);
            Assembly assembly = Assembly.LoadFile(filePath);
            var moduleInfos = assembly.GetExportedTypes().Where(IModuleType.IsAssignableFrom).Where(t => t != IModuleType).Where(t => !t.IsAbstract).Select(t => CreateModuleInfo(t, dllName));
            foreach (var moduleInfo in moduleInfos)
            {
                _moduleCatalog.AddModule(moduleInfo);
            }
        }

        void IStartUp.StartUp()
        {
            AddModule(DllName.AuthModule);
            LoadModule();
        }

        public IStartUp UseProject()
        {
            return this;
        }
    }
}