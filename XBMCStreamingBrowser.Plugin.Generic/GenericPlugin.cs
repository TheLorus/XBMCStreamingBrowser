using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBMCStreamingBrowser.Plugin.Generic
{
    public interface GenericPlugin
    {
        List<string> sites { get; }
        string resolve(Uri uri);
    }
}

