using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBuildStore
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.myBuildStoreDataSet.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.myBuildStoreDataSet.Categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.myBuildStoreDataSet.Products);

            dataGridView1.AutoGenerateColumns = true;
        }

        private void bindingNavigator3_RefreshItems(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            productsTableAdapter.Update(myBuildStoreDataSet);
            categoriesTableAdapter.Update(myBuildStoreDataSet);
            ordersTableAdapter.Update(myBuildStoreDataSet);

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = productsBindingSource;
            dataGridView1.DataSource = productsBindingSource;
            label1.Text = "Products";
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = categoriesBindingSource;
            dataGridView1.DataSource = categoriesBindingSource;
            label1.Text = "Categories";
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = ordersBindingSource;
            dataGridView1.DataSource = ordersBindingSource;
            label1.Text = "Orders";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void resettlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rs = new RSForm();
            rs.ShowDialog();
            categoriesTableAdapter.Fill(myBuildStoreDataSet.Categories);
            ordersTableAdapter.Fill(myBuildStoreDataSet.Orders);
            productsTableAdapter.Fill(myBuildStoreDataSet.Products);
        }
    }
}

