/*
 * this class is used for decreasing the environment noise by setting different values
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace Readerversion1._0
{
    public partial class Settingsensitive : Form
    {
        private System.Collections.ArrayList colorlist;
        private ArrayList chartlist = new ArrayList();
        private System.Collections.ArrayList distance = new System.Collections.ArrayList();
        private List<double> listX = new List<double>();
        private List<double> listY = new List<double>();
        private MethodEntity methodtemp;
        private ArrayList imagelist;
        private int adjustvalue = 0;
        private string content = "";
        private Pointentity setclassentity;
        public Settingsensitive()
        {
            InitializeComponent();
        }
        public Settingsensitive(ArrayList list, MethodEntity methodtempvalue)
        {
            System.Collections.ArrayList namelist=new ArrayList();
            imagelist=list;
            methodtemp = methodtempvalue;
            // TODO: Complete member initialization
            Pointentity temp = new Pointentity();
            InitializeComponent();
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
            Sensitivevalue.Text = "5";
            scanpicture(list);
            //this.colorlist = colorlist;
            for (int i = 0; i < methodtemp.getsettinglist().Count; i++)
            {
                namelist.Add(((Settingentity)methodtemp.getsettinglist()[i]).getparamatername());
            }
            for (int i = 0; i < namelist.Count; i++)
            {
                if (((Settingentity)methodtemp.getsettinglist()[i]).getlinevalue() != "Color")
                {
                    DateTime currenttime = DateTime.Now;
                    int colorvaluetop = 255;
                    int colorvaluebottom = 255;
                    ArrayList templist = new ArrayList();
                    int averagevalue = 0;
                    if (i < chartlist.Count)
                    {
                        TabPage tabPage = new TabPage();
                        tabPage.Text = "page" + i.ToString();
                        tabPage.ClientSize = new Size(749, 368);
                        tabPage.BackColor = Color.White;
                        Chart chart2 = new Chart();
                        chart2.Series.Clear();
                        chart2.ChartAreas.Add("ChartArea2");
                        chart2.Location = new Point(24, 17);
                        chart2.ClientSize = new Size(672, 300);
                        chart2.Margin = new Padding(3, 3, 3, 3);
                        chart2.ChartAreas["ChartArea2"].AxisX.Interval = 1;
                        chart2.ChartAreas["ChartArea2"].AxisY.Maximum = 300;
                        Series series = new Series("Spline");
                        chart2.Legends.Add(new Legend("Spline1"));

                        series.LegendText = namelist[i].ToString();
                        //series.Tag = "asda";
                        series.ChartType = SeriesChartType.Spline;
                        series.BorderWidth = 3;
                        colorlist = (System.Collections.ArrayList)chartlist[i];
                        for (int k = 0; k < colorlist.Count; k++)
                        {
                            temp = (Pointentity)colorlist[k];
                            series.Points.AddY(temp.getcolor());
                            if (temp.getcolor() < colorvaluetop && k < colorlist.Count / 2)
                            {
                                colorvaluetop = temp.getcolor();

                            }
                            else if (temp.getcolor() < colorvaluebottom && k > colorlist.Count / 2)
                            {
                                colorvaluebottom = temp.getcolor();
                            }

                        }
                        chart2.Series.Add(series);
                        tabPage.Controls.Add(chart2);
                        chart2.Show();
                        tabPage.Name = namelist[i].ToString();
                        tabPage.Text = namelist[i].ToString();
                        tabgroup.TabPages.Add(tabPage);
                        temp = (Pointentity)colorlist[0];
                        averagevalue = temp.getcolor();
                        colorvaluetop = averagevalue - colorvaluetop;
                        colorvaluebottom = averagevalue - colorvaluebottom;
                        TextAnnotation text = new TextAnnotation();
                        text.Text = "C:";
                        text.X = 85;
                        text.Y = 20;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = colorvaluetop.ToString();
                        text.X = 90;
                        text.Y = 20;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = "T:";
                        text.X = 85;
                        text.Y = 27;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = colorvaluebottom.ToString();
                        text.X = 90;
                        text.Y = 27;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = "Loading:";
                        text.X = 85;
                        text.Y = 34;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        System.DateTime timetemp = new DateTime();
                        TimeSpan ts = currenttime - timetemp;
                        text.Text = "0." + ts.Milliseconds.ToString() + "/s";
                        text.X = 92;
                        text.Y = 34;
                        chart2.Annotations.Add(text);
                    }
                }
            }
        }
        public void scanpicture(ArrayList list1)
        {
            chartlist.Clear();
            content = "";
            for (int k = 0; k < list1.Count; k++)
            {
                if (((Settingimageentity)list1[k]).getparamatertype() != "Color")
                {
                    Bitmap bitmap = ((Settingimageentity)list1[k]).getimage();
                    colorlist = new ArrayList();
                    bitmap = ToGray(bitmap);
                    int i = bitmap.Width / 2;
                    int temp = 255;
                    bool tempcount = false;
                    int average = 0;
                    ArrayList downsurge = new ArrayList();
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color colorcurrent = bitmap.GetPixel(i, j);
                        content = content + colorcurrent.B.ToString() + " ";
                        if (j < bitmap.Height - 2)
                        {
                            Color colorafter = bitmap.GetPixel(i, j + 2);
                            if (tempcount == false)//detectdowntrend
                            {
                                if (colorcurrent.B - colorafter.B >= int.Parse(Sensitivevalue.Text))
                                {
                                    tempcount = true;
                                }
                                else
                                {
                                    average = average + colorcurrent.B;
                                }
                            }
                            else if (tempcount == true)//detectuptrend
                            {
                                if (colorcurrent.B - colorafter.B <= -(int.Parse(Sensitivevalue.Text)))
                                {
                                    tempcount = false;//up
                                    downsurge.Add(j);
                                }
                                else
                                {
                                    downsurge.Add(j);
                                }
                            }
                        }
                        else
                        {
                            average = average + colorcurrent.B;
                        }

                    }
                    average = average / (bitmap.Height - downsurge.Count);
                    Color colorlast = bitmap.GetPixel(i, bitmap.Height - 1);
                    Color colorfirst = bitmap.GetPixel(i, 0);
                    int difference = Math.Abs(colorlast.B - colorfirst.B);
                    average = average + difference;
                    if (((Color)bitmap.GetPixel(i, (int)downsurge[0])).B > average)
                        average = ((Color)bitmap.GetPixel(i, (int)downsurge[0])).B;
                    if (((Color)bitmap.GetPixel(i, (int)downsurge[downsurge.Count - 1])).B > average)
                        average = ((Color)bitmap.GetPixel(i, (int)downsurge[downsurge.Count - 1])).B;
                    if (average > 255)
                        average = 255;
                    for (int j = 0, k1 = 0; j < bitmap.Height; j++)
                    {
                        if (j == (int)downsurge[k1])
                        {
                            if (k1 < downsurge.Count - 1)
                                k1++;
                            setclassentity = new Pointentity();
                            Color color = bitmap.GetPixel(i, j);
                            setclassentity.setcolor(color.B);
                            colorlist.Add(setclassentity);
                        }
                        else
                        {
                            setclassentity = new Pointentity();
                            Color color = Color.FromArgb(average, average, average);
                            setclassentity.setcolor(color.B);
                            colorlist.Add(setclassentity);
                        }

                    }
                    chartlist.Add(colorlist);
                }
                else
                {
                    Bitmap bitmap = (Bitmap)((Settingimageentity)list1[k]).getimage().Clone();
                    chartlist.Add(bitmap);
                }
            }
        }
        public static Bitmap ToGray(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                { 
                    Color color = bmp.GetPixel(i, j);
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }

        public void darwpicture()
        {
            System.Collections.ArrayList namelist=new ArrayList();
            Pointentity temp = new Pointentity();
            //this.colorlist = colorlist;
            for (int i = 0; i < methodtemp.getsettinglist().Count; i++)
            {
                namelist.Add(((Settingentity)methodtemp.getsettinglist()[i]).getparamatername());
            }
            for (int i = 0; i < namelist.Count; i++)
            {
                if (((Settingentity)methodtemp.getsettinglist()[i]).getlinevalue() != "Color")
                {
                    DateTime currenttime = DateTime.Now;
                    int colorvaluetop = 255;
                    int colorvaluebottom = 255;
                    ArrayList templist = new ArrayList();
                    int averagevalue = 0;
                    if (i < chartlist.Count)
                    {
                        TabPage tabPage = new TabPage();
                        tabPage.Text = "page" + i.ToString();
                        tabPage.ClientSize = new Size(749, 368);
                        tabPage.BackColor = Color.White;
                        Chart chart2 = new Chart();
                        chart2.Series.Clear();
                        chart2.ChartAreas.Add("ChartArea2");
                        chart2.Location = new Point(24, 17);
                        chart2.ClientSize = new Size(672, 300);
                        chart2.Margin = new Padding(3, 3, 3, 3);
                        chart2.ChartAreas["ChartArea2"].AxisX.Interval = 1;
                        chart2.ChartAreas["ChartArea2"].AxisY.Maximum = 300;
                        Series series = new Series("Spline");
                        chart2.Legends.Add(new Legend("Spline1"));

                        series.LegendText = namelist[i].ToString();
                        //series.Tag = "asda";
                        series.ChartType = SeriesChartType.Spline;
                        series.BorderWidth = 3;
                        colorlist = (System.Collections.ArrayList)chartlist[i];
                        for (int k = 0; k < colorlist.Count; k++)
                        {
                            temp = (Pointentity)colorlist[k];
                            series.Points.AddY(temp.getcolor());
                            if (temp.getcolor() < colorvaluetop && k < colorlist.Count / 2)
                            {
                                colorvaluetop = temp.getcolor();

                            }
                            else if (temp.getcolor() < colorvaluebottom && k > colorlist.Count / 2)
                            {
                                colorvaluebottom = temp.getcolor();
                            }

                        }
                        chart2.Series.Add(series);
                        tabPage.Controls.Add(chart2);
                        chart2.Show();
                        tabPage.Name = namelist[i].ToString();
                        tabPage.Text = namelist[i].ToString();
                        tabgroup.TabPages.Add(tabPage);
                        temp = (Pointentity)colorlist[0];
                        averagevalue = temp.getcolor();
                        colorvaluetop = averagevalue - colorvaluetop;
                        colorvaluebottom = averagevalue - colorvaluebottom;
                        TextAnnotation text = new TextAnnotation();
                        text.Text = "C:";
                        text.X = 85;
                        text.Y = 20;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = colorvaluetop.ToString();
                        text.X = 90;
                        text.Y = 20;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = "T:";
                        text.X = 85;
                        text.Y = 27;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = colorvaluebottom.ToString();
                        text.X = 90;
                        text.Y = 27;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = "Loading:";
                        text.X = 85;
                        text.Y = 34;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        System.DateTime timetemp = new DateTime();
                        TimeSpan ts = currenttime - timetemp;
                        text.Text = "0." + ts.Milliseconds.ToString() + "/s";
                        text.X = 92;
                        text.Y = 34;
                        chart2.Annotations.Add(text);
                    }
                }
            }
        }
        private void Settingsensitivetestbtn_Click(object sender, EventArgs e)
        {
            tabgroup.TabPages.Clear();
            scanpicture(imagelist);
            darwpicture();
            
        }

        private void Settingsensitivefinishbtn_Click(object sender, EventArgs e)
        {
            methodtemp.setsensitive(int.Parse(Sensitivevalue.Text));
            methodtemp.setadjustvalue(adjustvalue);
            this.Close();
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

        private void SettingsensitiveIncreasevaluebtn_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList namelist=new ArrayList();
            Pointentity temp = new Pointentity();
            //this.colorlist = colorlist;
            for (int i = 0; i < methodtemp.getsettinglist().Count; i++)
            {
                namelist.Add(((Settingentity)methodtemp.getsettinglist()[i]).getparamatername());
            }
            for (int i = 0; i < namelist.Count; i++)
            {
                if (i < chartlist.Count)
                {
                    colorlist = (System.Collections.ArrayList)chartlist[i];
                    for (int k = 0; k < colorlist.Count; k++)
                    {
                        ((Pointentity)colorlist[k]).setcolor(((Pointentity)colorlist[k]).getcolor()+10);
                    }
                }
            }
            adjustvalue = +10;
            tabgroup.TabPages.Clear();
            darwpicture();
            methodtemp.setadjustvalue(adjustvalue);
        }

        private void Settingsensitivedecreasebtn_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList namelist=new ArrayList();
            Pointentity temp = new Pointentity();
            //this.colorlist = colorlist;
            for (int i = 0; i < methodtemp.getsettinglist().Count; i++)
            {
                namelist.Add(((Settingentity)methodtemp.getsettinglist()[i]).getparamatername());
            }
            for (int i = 0; i < namelist.Count; i++)
            {
                if (i < chartlist.Count)
                {
                    colorlist = (System.Collections.ArrayList)chartlist[i];
                    for (int k = 0; k < colorlist.Count; k++)
                    {
                        ((Pointentity)colorlist[k]).setcolor(((Pointentity)colorlist[k]).getcolor() - 10);
                    }
                }
            }
            adjustvalue = -10;
            tabgroup.TabPages.Clear();
            darwpicture();
            methodtemp.setadjustvalue(adjustvalue);
        }

        private void Sensitivevalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == (int)(char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
