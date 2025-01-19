using System;
using System.Windows.Forms;
using MyBuildStore.MyBuildStoreDataSetTableAdapters;


namespace MyBuildStore
{
    public partial class EditForm : Form
    {
        // Змінні для збереження даних форми
        private bool edit; // true, якщо редагуємо запис, false - додаємо новий
        private int orderId; // ID замовлення, необхідний для редагування
        private string customerName;
        private DateTime orderDate;
        private string deliveryAddress;
        private int productId;
        private int quantity;
        private decimal totalPrice;

        // Додано посилання на OrdersTableAdapter
        private MyBuildStoreDataSetTableAdapters.ordersTableAdapter ordersTableAdapter;
        private MyBuildStoreDataSetTableAdapters.productsTableAdapter productsTableAdapter;

        // Конструктор для додавання нового запису
        public EditForm()
        {
            InitializeComponent();
            edit = false; // Додаємо новий запис

            // Ініціалізація адаптерів
            ordersTableAdapter = new MyBuildStoreDataSetTableAdapters.ordersTableAdapter();
            productsTableAdapter = new MyBuildStoreDataSetTableAdapters.productsTableAdapter();
        }

        // Конструктор для редагування існуючого запису
        public EditForm(int orderId, string customerName, DateTime orderDate, string deliveryAddress, int productId, int quantity, decimal totalPrice)
            : this() // Викликаємо конструктор без параметрів (для ініціалізації форми)
        {
            this.orderId = orderId;
            this.edit = true; // Ми редагуємо існуючий запис
            this.customerName = customerName;
            this.orderDate = orderDate;
            this.deliveryAddress = deliveryAddress;
            this.productId = productId;
            this.quantity = quantity;
            this.totalPrice = totalPrice;

            // Заповнення полів форми даними
            textBox_Name.Text = customerName;
            dateTimePicker_OrderDate.Value = orderDate;
            textBox_Adress.Text = deliveryAddress;
            comboBox_Products.SelectedValue = productId;
            textBox_Quanity.Text = quantity.ToString();
            textBox_Price.Text = totalPrice.ToString("F2");
        }

        // Завантаження даних у форму
        private void EditForm_Load(object sender, EventArgs e)
        {
            // Завантаження продуктів для comboBox
            this.productsTableAdapter.Fill(this.myBuildStoreDataSet.products);
        }

        // Логіка для кнопки OK (Збереження даних)
        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо дані з форми
                string customerName = textBox_Name.Text;
                string orderDate = dateTimePicker_OrderDate.Value.ToString("yyyy-MM-dd"); // Форматування дати в рядок
                string deliveryAddress = textBox_Adress.Text;
                int productId = (int)comboBox_Products.SelectedValue;
                int quantity = int.Parse(textBox_Quanity.Text);
                decimal totalPrice = decimal.Parse(textBox_Price.Text);

                if (edit) // Якщо редагуємо запис
                {
                    // Викликаємо метод для оновлення даних
                    ordersTableAdapter.UpdateOrderQuery(customerName, orderDate, deliveryAddress, productId, quantity, totalPrice, orderId);
                }
                else // Якщо додаємо новий запис
                {
                    // Викликаємо метод для додавання нового запису
                    ordersTableAdapter.InsertOrderQuery(customerName, orderDate, deliveryAddress, productId, quantity, totalPrice);
                }

                // Закриваємо форму після збереження
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        // Логіка для кнопки Cancel (Скасувати зміни)
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Просто закриває форму
        }

        private void comboBox_Products_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
