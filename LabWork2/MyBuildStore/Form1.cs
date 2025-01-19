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
            dataGridView1.AutoGenerateColumns = true;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.myBuildStoreDataSet.orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.myBuildStoreDataSet.categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myBuildStoreDataSet.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.myBuildStoreDataSet.products);

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
            categoriesTableAdapter.Fill(myBuildStoreDataSet.categories);
            ordersTableAdapter.Fill(myBuildStoreDataSet.orders);
            productsTableAdapter.Fill(myBuildStoreDataSet.products);
        }

        private void queryEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var qe = new QueryEdit();
            qe.Show();

        }

        private bool edit;
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = false; // Якщо додаємо новий запис, редагування вимикається
            var edt = new EditForm(); // Створення нової форми для додавання
            edt.ShowDialog();

            // Після того, як форма закрита, оновлюємо дані
            ordersTableAdapter.Fill(myBuildStoreDataSet.orders);
            myBuildStoreDataSet.AcceptChanges();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Перевірка, чи вибрано рядок у DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edit = true; // Якщо редагуємо запис, то включаємо режим редагування

                // Отримуємо дані з вибраного рядка
                var row = dataGridView1.SelectedRows[0];
                int orderId = Convert.ToInt32(row.Cells["order_id"].Value);
                string customerName = row.Cells["customer_name"].Value.ToString();
                DateTime orderDate = Convert.ToDateTime(row.Cells["order_date"].Value);
                string deliveryAddress = row.Cells["delivery_address"].Value.ToString();
                int productId = Convert.ToInt32(row.Cells[0].Value);
                int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                decimal totalPrice = Convert.ToDecimal(row.Cells["total_price"].Value);

                // Створення форми для редагування з передачею даних
                var edt = new EditForm(orderId, customerName, orderDate, deliveryAddress, productId, quantity, totalPrice);
                edt.ShowDialog();

                // Оновлення даних після редагування
                ordersTableAdapter.Fill(myBuildStoreDataSet.orders);
                myBuildStoreDataSet.AcceptChanges();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть замовлення для редагування.");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Проверяем, что строка выделена
            {
                int orderId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["order_id"].Value); // Получаем order_id из выбранной строки

                try
                {
                    // Удаляем запись из базы данных
                    ordersTableAdapter.DeleteQuery(orderId);

                    // Обновляем данные в DataGridView
                    ordersTableAdapter.Fill(myBuildStoreDataSet.orders);
                    myBuildStoreDataSet.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.");
            }
        }
    }
}
