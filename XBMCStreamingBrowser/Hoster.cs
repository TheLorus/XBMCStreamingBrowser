using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBMCStreamingBrowser
{
    class Hoster
    {
        public int id { get; set; }
        public string name { get; set; }
        public int mirrors { get; set; }

        public Hoster(int id, string name, int mirrors)
        {
            this.id = id;
            this.name = name;
            this.mirrors = mirrors;
        }
    }
}
