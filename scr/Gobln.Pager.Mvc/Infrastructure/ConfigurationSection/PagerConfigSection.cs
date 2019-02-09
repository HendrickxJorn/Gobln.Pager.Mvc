//#if !NETCOREAPP2_0

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Configuration;

//namespace Gobln.Pager.Mvc.Infrastructure
//{
//    public class PagerConfigSection : ConfigurationSection
//    {
//        /// <summary>
//        /// Initialize <see cref="PagerConfigSection"/>
//        /// </summary>
//        /// <param name="path">Path in the config where the section is located. ['sectionGroup name'/'section name'] Excample: 'Logging/LogSection'</param>
//        /// <returns></returns>
//        public static PagerConfigSection GetSection(string path)
//        {
//            var configuration = (PagerConfigSection)ConfigurationManager.GetSection(path);
//            return configuration ?? new PagerConfigSection();
//        }
//    }
//}

//#endif