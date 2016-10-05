using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Readerversion1._0
{
    public partial class TestlineSetting : Form
    {
        private Settingentity settingentity;
        public TestlineSetting(Settingentity value)
        {
            InitializeComponent();
            settingentity = value;
        }

        private void TestlineSetting_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn From = new DataGridViewTextBoxColumn();
            dataGridView1.AllowUserToAddRows = false;
            From.Name = "From";
            From.DataPropertyName = "From";
            From.HeaderText = "From";
            From.ValueType=typeof(Int32);
            dataGridView1.Columns.Add(From);
            DataGridViewTextBoxColumn To = new DataGridViewTextBoxColumn();
            To.Name = "To";
            To.DataPropertyName = "To";
            To.HeaderText = "To";
            To.ValueType = typeof(Int32);
            dataGridView1.Columns.Add(To);
            DataGridViewTextBoxColumn Result = new DataGridViewTextBoxColumn();
            Result.Name = "Result";
            Result.DataPropertyName = "Result";
            Result.HeaderText = "Result";
            Result.ValueType=typeof(String);
            dataGridView1.Columns.Add(Result);
            if (settingentity.getresultentitylist().Count != 0)
            {
                for (int i = 0; i < settingentity.getresultentitylist().Count; i++)
                {
                    if (((ResultEntity)settingentity.getresultentitylist()[i]).getresultname() == "Test line")
                    {
                        string[] row = { ((ResultEntity)settingentity.getresultentitylist()[i]).getresultstartvalue().ToString(), ((ResultEntity)settingentity.getresultentitylist()[i]).getresultendvalue().ToString(), ((ResultEntity)settingentity.getresultentitylist()[i]).getresultvalue() };
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
        }

        private void TestingSettingsavebtn_Click(object sender, EventArgs e)
        {
            settingentity.getresultentitylist().Clear();
            int row = dataGridView1.Rows.Count;//get the number of rows  
            int cell = 3;
            for (int i = 0; i < row; i++)
            {
                ResultEntity temp = new ResultEntity();
                temp.setresultname("Test line");
                for (int j = 0; j < cell; j++)//get the number of columns and loop by it 
                {
                    if (j % 3 == 0)
                    {
                        temp.setresultstartvalue(int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()));
                    }
                    else if (j % 3 == 1)
                    {
                        temp.setresultendvalue(int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()));
                    }
                    else if (j % 3 == 2)
                    {
                        temp.setresultvalue(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }

                }
                settingentity.getresultentitylist().Add(temp);
            }
            this.Close();
        }

        private void TestlineSettingdeletebtn_Click(object sender, EventArgs e)//delete the row which has been chosen 
        {
            if (dataGridView1.SelectedRows.Count!=0)
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }

        private void TestlineSettingaddbtn_Click(object sender, EventArgs e)//add new rows depends on the TestlineSettingRecordsvalue value
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < int.Parse(TestlineSettingRecordsvalue.Text.ToString()); i++)
            {
                dataGridView1.Rows.Add(new DataGridViewRow());
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("please input number");
        }

        private void TestlineSettingRecordsvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == (int)(char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
