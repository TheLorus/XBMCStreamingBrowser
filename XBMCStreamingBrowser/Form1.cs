using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using XBMCStreamingBrowser.Plugin.Generic;

namespace XBMCStreamingBrowser
{
    public partial class Form1 : Form
    {

        List<string> _names = new List<string>();

	    /// <summary>
	    /// Contains column data arrays.
	    /// </summary>
	    List<double[]> _dataArray = new List<double[]>();


        public Form1()
        {
            InitializeComponent();
            PluginHandler.Initialize();
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            var resolved = PluginHandler.Resolve(textBox1.Text);
            if (!String.IsNullOrEmpty(resolved))
            {
                MessageBox.Show(resolved);
            }
            else
            {
                MessageBox.Show("Kein Plugin gefunden");
            }
        }
        */
 
        private static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {

            Point pt = new Point(e.X, e.Y);
            ListBox lb = ((ListBox)sender);
            int index = lb.IndexFromPoint(pt);
            if (index >= 0)
            {
                lb.SetSelected(index, true);
            }
                
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }


        public DataTable GetSearchResult(string search)
        {

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            // Create the output table.
            DataTable d = new DataTable();

            d.Columns.Add("language", typeof (string));
            d.Columns.Add("type", typeof(string));
            d.Columns.Add("url", typeof(string));
            d.Columns.Add("title", typeof(string));
            d.Columns.Add("year", typeof(string));

            string url = "http://kinox.to/Search.html?q=" + HttpUtility.UrlEncode(search);
            var resp = wc.DownloadString(url);


            try
            {
                Regex regexObj = new Regex(@"<td class=""Icon""><img width=""16"" height=""11"" src=""/gr/sys/lng/(\d+).png"" alt=""language""></td>.*?title=""([^""]+)"".*?<td class=""Title"">.*?<a href=""(.*?)"".*?>(.*?)</a>.*?class=""Year"">(.*?)</span>", RegexOptions.Singleline);
                Match matchResults = regexObj.Match(resp);
                while (matchResults.Success)
                {
                    /*
                    byte[] imageData = wc.DownloadData("http://kinox.to/" + matchResults.Groups[1].Value);
                    var stream = new MemoryStream(imageData);
                    Image img = Image.FromStream(stream);
                    stream.Close();
                    */
                    if (matchResults.Groups[1].Value == "1" || matchResults.Groups[1].Value == "15")
                    {
                        byte[] bytes = Encoding.Default.GetBytes(matchResults.Groups[4].Value);
                        var title = Encoding.UTF8.GetString(bytes);

                        string resultUrl = "http://www.kinox.to"+matchResults.Groups[3].Value.ToString();

                        d.Rows.Add(matchResults.Groups[1].Value, matchResults.Groups[2].Value, resultUrl, matchResults.Groups[4].Value, matchResults.Groups[5].Value);
                    }

                       

                    matchResults = matchResults.NextMatch();
                }
            }
            catch (ArgumentException)
            {
                // Syntax error in the regular expression
            }




            return d;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchResult.DataSource = GetSearchResult(searchInput.Text);
            searchResult.Columns["language"].Visible = false;
            searchResult.Columns["type"].Visible = false;
            searchResult.Columns["url"].Visible = false;
            searchResult.Columns["title"].Width = 260;
            searchResult.Columns["year"].Width = 62;
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            string url = searchResult.SelectedRows[0].Cells["url"].Value.ToString();
            StreamInfo info = new StreamInfo(url);
            info.ShowDialog();
        }

    }
}
