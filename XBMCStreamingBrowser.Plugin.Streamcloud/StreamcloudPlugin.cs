using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using XBMCStreamingBrowser.Plugin.Generic;

namespace XBMCStreamingBrowser.Plugin.Streamcloud
{
    public class StreamcloudPlugin : GenericPlugin
    {
        private List<String> _sites = new List<string>();

        public List<String> sites
        {
            get
            {
                _sites.Add("streamcloud.eu");
                return _sites;
            }
        }


        public string resolve(Uri uri)
        {
            var client = new WebClient();
            var reqParams = new NameValueCollection();

            var response = client.DownloadString(uri);

            var regexObj = new Regex("<input.*?name=\"(.*?)\".*?value=\"(.*?)\">", RegexOptions.Singleline);
            var matchResults = regexObj.Match(response);
            while (matchResults.Success)
            {
                reqParams.Add(matchResults.Groups[1].Value, matchResults.Groups[2].Value);
                matchResults = matchResults.NextMatch();
            }

            Thread.Sleep(11000);

            byte[] responsebytes = client.UploadValues(uri, "POST", reqParams);
            string responsebody = Encoding.UTF8.GetString(responsebytes);

            string resolved = Regex.Match(responsebody, "file: \"(.+?)\",", RegexOptions.Singleline).Groups[1].Value;

            if (!String.IsNullOrEmpty(resolved))
            {
                return resolved;
            }
            else
            {
                throw new Exception("File not found!");
            }           
        }
    }
}
