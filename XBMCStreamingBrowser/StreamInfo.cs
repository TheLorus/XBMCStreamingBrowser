using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace XBMCStreamingBrowser
{
    public partial class StreamInfo : Form
    {

        private string _url = "";
        private List<KeyValuePair<int, int>> _seasons = new List<KeyValuePair<int, int>>();
        private List<Hoster> _hosterList = new List<Hoster>();
        private string _seriesId = "";
        WebClient wc = new WebClient();

        public StreamInfo(string url)
        {
            InitializeComponent();
            _url = url;

            var resp = wc.DownloadString(url);

            Regex regexObj = new Regex(@"<li id=""Hoster_(.*?)"".*?class=""Named"">(.*?)</div>.*?<b>Mirror</b>:.*?/(.*?)<br />", RegexOptions.Singleline);
            Match matchResults = regexObj.Match(resp);

            List<Hoster> hosterList = new List<Hoster>();

            while (matchResults.Success)
            {
                int id = int.Parse(matchResults.Groups[1].Value);
                string name = matchResults.Groups[2].Value;
                int mirrors = int.Parse(matchResults.Groups[3].Value);

                Hoster hoster = new Hoster(id, name, mirrors);
                hosterList.Add(hoster);

                matchResults = matchResults.NextMatch();
            }

            HosterBox.DataSource = hosterList;
            HosterBox.DisplayMember = "name";

        }

        private List<KeyValuePair<int, int>> getSeasonList()
        {

            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();

            var resp = wc.DownloadString(_url);

            Regex regexObj = new Regex(@"id=""SeasonSelection"" rel=""(.*?)""", RegexOptions.Singleline);
            Match matchResults = regexObj.Match(resp);

            if (!matchResults.Success)
            {
                return null;
            }
            else
            {
                _seriesId = matchResults.Groups[1].Value;
                resp = wc.DownloadString(_url);

                Regex regexObj2 = new Regex(@"<option value=""(.*?) rel="".*,(.*?)""", RegexOptions.Singleline);
                matchResults = regexObj2.Match(resp);

                while (matchResults.Success)
                {
                    list.Add(new KeyValuePair<int,int>(int.Parse(matchResults.Groups[1].Value), int.Parse(matchResults.Groups[1].Value)));
                    matchResults = matchResults.NextMatch();
                }
                return list;

            }
           
        }

        private void HosterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MirrorBox.Items.Clear();
            var selectedHoster = (Hoster)HosterBox.SelectedItem;

            for (int i = 1; i <= selectedHoster.mirrors; i++)
            {
                MirrorBox.Items.Add(i.ToString());
            }

            var random = new Random();
            int rnd = random.Next(0, MirrorBox.Items.Count - 1);
            MirrorBox.SelectedIndex = rnd;
        }
    }
}
