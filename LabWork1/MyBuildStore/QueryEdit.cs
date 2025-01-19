using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyBuildStore
{
    public partial class QueryEdit : Form
    {
        const string ConnectionString = @"Data Source=DESKTOP-24T9T4O;Initial Catalog=MyBuildStore;Integrated Security=True;Encrypt=False";
        public QueryEdit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(TestInput.Text, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestInput.Clear();
            TestInput.Text = "Select";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
