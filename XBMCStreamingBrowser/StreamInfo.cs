﻿using System;
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
using XBMCStreamingBrowser.Plugin.Generic;

namespace XBMCStreamingBrowser
{
    public partial class StreamInfo : Form
    {

        private string _url = "";
        private List<KeyValuePair<int, int>> _seasons = new List<KeyValuePair<int, int>>();
        private List<Hoster> _hosterList = new List<Hoster>();
        private string _seriesUrl = "";
        private string _mainString;
        WebClient wc = new WebClient();
        private string _hosterLink = "";

        public StreamInfo(string url)
        {
            InitializeComponent();

            Regex regexObj = new Regex(@"http://www.kinox.to/Stream/(.*?).html", RegexOptions.Singleline);
            Match matchResults = regexObj.Match(url);
            _mainString = matchResults.Groups[1].Value;
            setMirror(url);
        }

        private void setMirrorByEpisode(string season, string episode)
        {
            string url = String.Format("http://kinox.to/aGET/MirrorByEpisode/{0}&Season={1}&Episode={2}", _seriesUrl, season, episode);
            setMirror(url, true);
        }

        private void setHosterLink()
        {
            Hoster hosterObj = (Hoster)BoxHoster.SelectedItem;
            string hoster = hosterObj.id.ToString();
            string mirror = BoxMirror.SelectedItem.ToString();

            string url = String.Format("http://kinox.to/aGET/Mirror/{0}&Hoster={1}&Mirror={2}", _mainString, hoster, mirror);

            if (BoxSeason.SelectedItem != null && BoxSeason.Enabled == true)
            {
                string season = BoxSeason.SelectedItem.ToString();
                url += String.Format("&Season={0}", season);
            }

            if (BoxEpisode.SelectedItem != null && BoxEpisode.Enabled == true)
            {
                string episode = BoxEpisode.SelectedItem.ToString();
                url += String.Format("&Episode={0}", episode);
            }

            if (BoxPart.SelectedItem != null && BoxPart.Enabled == true)
            {
                string part = BoxPart.SelectedItem.ToString();
                url += String.Format("&Part={0}", part);
            }

            string result = wc.DownloadString(url);
            string resultString = Regex.Match(result, @"<a href=\\""(.*?)""", RegexOptions.Singleline).Groups[1].Value;

            _hosterLink = System.Text.RegularExpressions.Regex.Unescape(resultString);
            LabelHosterLink.Text = _hosterLink;


        }

        private void setPart()
        {

            Hoster hosterObj = (Hoster)BoxHoster.SelectedItem;
            string hoster = hosterObj.id.ToString();
            string mirror = BoxMirror.SelectedItem.ToString();

            string url = String.Format("http://kinox.to/aGET/Mirror/{0}&Hoster={1}&Mirror={2}", _mainString, hoster, mirror);

            if (BoxSeason.SelectedItem != null && BoxEpisode.SelectedItem != null)
            {
                string season = BoxSeason.SelectedItem.ToString();
                string episode = BoxEpisode.SelectedItem.ToString();

                url = url + String.Format("&Season={0}&Episode={1}", season, episode);
            }

            string result = wc.DownloadString(url);

            Regex regexObj = new Regex(@"Part (.*?)<", RegexOptions.Compiled);
            Match matchResults = regexObj.Match(result);

            int maxPart = 0;

            while (matchResults.Success)
            {
                maxPart = int.Parse(matchResults.Groups[1].Value);
                matchResults = matchResults.NextMatch();
            }

            if (maxPart != 0)
            {
                BoxPart.Enabled = true;
                LabelPart.Enabled = true;

                BoxPart.Items.Clear();

                for (int i = 1; i <= maxPart; i++)
                {
                    BoxPart.Items.Add(i);
                }

                BoxPart.SelectedIndex = 0;

            }
            else
            {
                BoxPart.Enabled = false;
                LabelPart.Enabled = false;
            }
        }

        private void setMirror(string url, bool isSeries=false)
        {
            _url = url;

            if (_seasons.Count == 0)
            {
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

            BoxHoster.DataSource = hosterList;
            BoxHoster.DisplayMember = "name";
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
            BoxMirror.Items.Clear();
            var selectedHoster = (Hoster)BoxHoster.SelectedItem;

            for (int i = 1; i <= selectedHoster.mirrors; i++)
            {
                BoxMirror.Items.Add(i.ToString());
            }

            var random = new Random();
            int rnd = random.Next(0, BoxMirror.Items.Count - 1);
            BoxMirror.SelectedIndex = rnd;
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

            setMirrorByEpisode(BoxSeason.SelectedItem.ToString(), BoxEpisode.SelectedItem.ToString());
        }

        private void BoxEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            setMirrorByEpisode(BoxSeason.SelectedItem.ToString(), BoxEpisode.SelectedItem.ToString());
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            var resolved = PluginHandler.Resolve(_hosterLink);
            if (!String.IsNullOrEmpty(resolved))
            {
                LabelPlay.Text = resolved;
            }
            else
            {
                MessageBox.Show("Kein Plugin gefunden");
            }
        }

        private void BoxMirror_SelectedIndexChanged(object sender, EventArgs e)
        {
            setHosterLink();
        }

        private void BoxPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            setHosterLink();
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            var test = new JsonRpcClient();
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");

                var json1 = @"{""jsonrpc"": ""2.0"", ""method"": ""Player.Open"", ""params"":{""item"":{""file"":"""+LabelPlay.Text+@"""}}, ""id"": 1}";

                string response = client.UploadString("http://xbmc:xmbc@192.168.178.24/jsonrpc", json1);
            }
        }
    }
}
