using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBMCStreamingBrowser.Plugin.Generic;

namespace XBMCStreamingBrowser
{
    class PluginHandler
    {
        public static Dictionary<List<string>, GenericPlugin> Plugins = new Dictionary<List<string>, GenericPlugin>();

        public static void Initialize()
        {
            ICollection<GenericPlugin> plugins = GenericPluginLoader<GenericPlugin>.LoadPlugins("Plugins");
            if (plugins != null)
            {
                foreach (var item in plugins)
                {
                    Plugins.Add(item.sites, item);
                }
            }
        }

        public static string Resolve(string url)
        {
            return Resolve(new Uri(url));
        }

        private static string Resolve(Uri uri)
        {

            if (Plugins != null)
            {
                foreach (KeyValuePair<List<string>, GenericPlugin> Plugin in Plugins)
                {
                    foreach (string site in Plugin.Key)
                    {
                        if (site.Equals(uri.Host))
                        {
                            return Plugin.Value.resolve(uri);
                        }
                    }
                }     
            }

            return null;
        }
    }
}
