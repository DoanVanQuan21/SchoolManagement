﻿using DryIoc;
using Prism.Ioc;
using System.Diagnostics;

namespace SchoolManagement.Core.avalonia
{
    public static class Ioc
    {
        public static IContainer AppContainer { get; set; }
        public static IContainerRegistry ContainerRegistry { get; set; }
        public static IContainerProvider ContainerProvider { get; set; }

        public static void RegisterSingleton<TFrom, TTo>() where TTo : TFrom
        {
            if (!ContainerRegistry.IsRegistered<TFrom>())
            {
                ContainerRegistry.RegisterSingleton<TFrom, TTo>();
            }
        }

        public static T Resolve<T>()
        {
            var ins = AppContainer.Resolve<T>();
            if (ins == null)
            {
                Debug.WriteLine($"{typeof(T)} is not register");
                return default(T);
            }
            return ins;
        }
    }
}