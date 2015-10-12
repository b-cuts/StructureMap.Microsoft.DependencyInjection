﻿using System;

namespace StructureMap
{
    internal sealed class StructureMapServiceProvider : IServiceProvider
    {
        public StructureMapServiceProvider(IContainer container)
        {
            Container = container;
        }

        private IContainer Container { get; }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsGenericEnumerable())
            {
                // Ideally we'd like to call TryGetInstance here as well,
                // but StructureMap does't like it for some weird reason.
                return Container.GetInstance(serviceType);
            }

            return Container.TryGetInstance(serviceType);
        }
    }
}
