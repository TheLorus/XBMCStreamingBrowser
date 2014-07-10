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
        private string _seriesUrl = "";
        WebClient wc = new WebClient();

        public StreamInfo(string url)
        {
            InitializeComponent();
            _url = url;

            _seasons = getSeasonList();
            if (_seasons != null)
            {
                BoxSeason.Enabled = true;
                LabelSeason.Enabled = true;
                foreach (KeyValuePair<int, int> season in _seasons)
                {
                    BoxSeason.Items.Add(season.Key.ToString());
                }

                BoxSeason.SelectedIndex = 0;
            }

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
                _seriesUrl = matchResults.Groups[1].Value;

                Regex regexObj2 = new Regex(@"<option value=""(.*?)"" rel="".*?,(.*?)"".*?</option>", RegexOptions.Compiled);
                Match matchResults2 = regexObj2.Match(resp);

                foreach (Match match in regexObj2.Matches(resp))
                {
                    string[] last = match.Groups[2].Value.Split(',');
                    int ilast = int.Parse(last[last.Length - 1]);
                    list.Add(new KeyValuePair<int,int>(int.Parse(match.Groups[1].Value), ilast));
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

        private void BoxSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            BoxEpisode.Enabled = true;
            LabelEpisode.Enabled = true;
            BoxEpisode.Items.Clear();
            int season = int.Parse(BoxSeason.SelectedItem.ToString());
            int max = _seasons[season-1].Value;
            for (int i = 1; i <= max; i++)
            {
                BoxEpisode.Items.Add(i);
            }
            BoxEpisode.SelectedIndex = 0;
        }
    }
}
