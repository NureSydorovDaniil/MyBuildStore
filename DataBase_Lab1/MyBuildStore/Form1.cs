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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.myBuildStoreDataSet.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.myBuildStoreDataSet.Categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.myBuildStoreDataSet.Products);
            dataGridView1.AutoGenerateColumns = true;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            productsTableAdapter.Update(myBuildStoreDataSet);
            categoriesTableAdapter.Update(myBuildStoreDataSet);
            ordersTableAdapter.Update(myBuildStoreDataSet);
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = productsBindingSource;
            dataGridView1.DataSource = productsBindingSource;
            label1.Text = "Products";
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = categoriesBindingSource;
            dataGridView1.DataSource = categoriesBindingSource;
            label1.Text = "Categories";
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = ordersBindingSource;
            dataGridView1.DataSource = ordersBindingSource;
            label1.Text = "Orders";
        }

        private void orderViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rs = new RSForm();
            rs.ShowDialog();
            categoriesTableAdapter.Fill(myBuildStoreDataSet.Categories);
            ordersTableAdapter.Fill(myBuildStoreDataSet.Orders);
            productsTableAdapter.Fill(myBuildStoreDataSet.Products);

        }
    }
}
