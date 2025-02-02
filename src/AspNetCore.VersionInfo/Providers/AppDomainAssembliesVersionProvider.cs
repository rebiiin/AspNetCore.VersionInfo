﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.VersionInfo.Providers
{
    public class AppDomainAssembliesVersionProvider : IInfoProvider
    {
        public string Name => nameof(AppDomainAssembliesVersionProvider);

        public IDictionary<string, string> GetData()
        {
            var dict = new SortedDictionary<string, string>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                if (!dict.ContainsKey(assembly.GetName().Name))
                {
                    dict.Add(assembly.GetName().Name, assembly.GetName().Version.ToString());
                }
            }

            return dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
