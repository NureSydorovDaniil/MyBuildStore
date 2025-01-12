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
    public partial class RSForm : Form
    {
        public RSForm()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myBuildStoreDataSet);

        }

        private void RSForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.myBuildStoreDataSet.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.myBuildStoreDataSet.Products);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите подтвердить изменения?", "Изменение данных", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                productsBindingSource.EndEdit();
                productsTableAdapter.Update(myBuildStoreDataSet);
                ordersTableAdapter.Update(myBuildStoreDataSet);
            }
        }

        private void productIDLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
