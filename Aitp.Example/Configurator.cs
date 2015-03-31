using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Practices.Unity;

namespace Aitp.Example
{
    public static class Configurator
    {
        public static IUnityContainer Configure(IUnityContainer container)
        {
            // Register type mappings to Unity

            // Register AutoMapper mappings

            return container;
        }
    }

}
