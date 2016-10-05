using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Readerversion1._0
{
    public partial class Chooselanguage : Form
    {
        private Form1 tempform;
        public Chooselanguage(Form1 form)
        {
            InitializeComponent();
            tempform = form;
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
        }

        private void Chooselanguage_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + "\\Languagelist.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                Regex reg = new Regex("LanguageName:");//read the LanguageName which includes the categories of the supported language
                MatchCollection match = reg.Matches(line);
                if (match.Count != 0)
                {
                    line = sr.ReadLine();
                    string[] result = Regex.Split(line, ",| ,|, ");
                    for (int i = 0; i < result.Length; i++)
                    {
                        languageselectbox.Items.Add(result[i]);
                    }
                    languageselectbox.SelectedIndex = 0;
                }
            }
        }

        private void Languagefinishbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Chooselanguage_FormClosing(object sender, FormClosingEventArgs e)
        {
            tempform.refreshlanguage(languageselectbox.Text);
        }
        internal void refreshlanguage(string name)
        {
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + "\\" + name + ".txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                Regex reg = new Regex("[A-Za-z0-9]*:");
                MatchCollection match = reg.Matches(line);
                if (match.Count != 0)
                {
                    reg = new Regex("[A-Za-z0-9]+");
                    match = reg.Matches(match[0].ToString());
                    string result = sr.ReadLine();
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (this.Controls[i].Name == match[0].ToString())
                        {
                            this.Controls[i].Text = result;
                        }
                    }
                }
            }

        }
    }
}
