﻿using Business.IoC;
using Business.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        { 
        foreach(var module in modules)
            {
                module.load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
