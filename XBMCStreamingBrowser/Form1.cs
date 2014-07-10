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
            listBox1.AutoSize = true;
        }

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

        private void listBox1_Click(object sender, EventArgs e)
        {
            textBox2.Text = listBox1.SelectedItem.ToString();
            listBox1.Hide();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            WebClient wc = new WebClient();
            string url = String.Format("http://kinox.to/aGET/Suggestions/?q={0}&limit=10?q=hang&limit=10", textBox2.Text);
            var resp = wc.DownloadString(url);
            string[] suggestions = resp.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            listBox1.Items.Clear();
            foreach (var sug in suggestions)
            {
                if (!String.IsNullOrEmpty(sug))
                {
                    listBox1.Items.Add(sug);
                }
            }

            if (listBox1.Items.Count > 0)
            {
                listBox1.Show();
            }
            else
            {
                listBox1.Hide();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                Regex regexObj = new Regex(@"<td class=""Icon""><img width=""16"" height=""11"" src=""/gr/sys/lng/(\d+).png"" alt=""language""></td>.*?title=""([^""]+)"".*?<td class=""Title"">.*?<a href=""(.*?)"">(.*?)</a>.*?class=""Year"">(.*?)</span>", RegexOptions.Singleline);
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
                        d.Rows.Add(matchResults.Groups[1].Value, matchResults.Groups[2].Value, matchResults.Groups[3].Value, matchResults.Groups[4].Value, matchResults.Groups[5].Value);
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
            dataGridView1.DataSource = GetSearchResult(textBox2.Text);
            dataGridView1.Columns[2].Visible = false;
        }

    }
}
