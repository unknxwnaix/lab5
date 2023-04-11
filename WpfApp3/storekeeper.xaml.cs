using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3.sales_dbDataSetTableAdapters;
namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для storekeeper.xaml
    /// </summary>
    public partial class storekeeper : Window
    {
        productsTableAdapter product = new productsTableAdapter();
        ordersTableAdapter order = new ordersTableAdapter();
        order_itemsTableAdapter order_items = new order_itemsTableAdapter();
        paymentsTableAdapter payment = new paymentsTableAdapter();
        suppliersTableAdapter supplier = new suppliersTableAdapter();
        supplier_productsTableAdapter supplier_product = new supplier_productsTableAdapter();
        employeesTableAdapter employee = new employeesTableAdapter();
        customersTableAdapter customer = new customersTableAdapter();
        order_itemsTableAdapter order_item = new order_itemsTableAdapter();
        public storekeeper()
        {
            InitializeComponent();
            FullUpdate();
        }
        public void FullUpdate()
        {
            dg_Order.ItemsSource = order.GetData();
            cbx_Order.ItemsSource = employee.GetData();
            cbx_Order.DisplayMemberPath = "имя";
            cbx_Order.SelectedValuePath = "айди";
            cbx_Order3.ItemsSource = customer.GetData();
            cbx_Order3.DisplayMemberPath = "имя";
            cbx_Order3.SelectedValuePath = "айди";
            dg_Supplier_Product.ItemsSource = supplier_product.GetData();
            cbx_Supplier_Product.ItemsSource = supplier.GetData();
            cbx_Supplier_Product.DisplayMemberPath = "имя";
            cbx_Supplier_Product.SelectedValuePath = "айди";
            cbx_Supplier_Product1.ItemsSource = product.GetData();
            cbx_Supplier_Product1.DisplayMemberPath = "название";
            cbx_Supplier_Product1.SelectedValuePath = "айди";
            dg_payment.ItemsSource = payment.GetData();
            cbx_payment.ItemsSource = order.GetData();
            cbx_payment.DisplayMemberPath = "сумма";
            cbx_payment.SelectedValuePath = "айди";
            dg_Order_Item.ItemsSource = order_item.GetData();
            cbx_Order_Item1.ItemsSource = product.GetData();
            cbx_Order_Item1.DisplayMemberPath = "цена";
            cbx_Order_Item1.SelectedValuePath = "айди";
            cbx_Order_Item.ItemsSource = product.GetData();
            cbx_Order_Item.DisplayMemberPath = "название";
            cbx_Order_Item.SelectedValuePath = "айди";
        }

        private void Button_Click_Create_Order(object sender, RoutedEventArgs e)
        {
            if (cbx_Order.Text != null && cbx_Order.Text != "" && tb_Order1.Text != null && tb_Order1.Text != "" && tb_Order2.Text != null && tb_Order2.Text != "" && cbx_Order3.Text != null && cbx_Order3.Text != "" && Convert.ToInt32(tb_Order2.Text) > 0)
            {

                int a = Convert.ToInt32(cbx_Order.SelectedValue.ToString());
                int b = Convert.ToInt32(cbx_Order3.SelectedValue.ToString());
                decimal c = Convert.ToDecimal(tb_Order2.Text.ToString());
                order.InsertQueryOrder(a ,tb_Order1.Text,c, b);
                dg_Order.ItemsSource = order.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_Order(object sender, RoutedEventArgs e)
        {
            if (dg_Order.SelectedValue != null)
            {
                var value = (dg_Order.SelectedValue as DataRowView).Row[0];
                order.DeleteQueryOrder((int)value);
                dg_Order.ItemsSource = order.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_Order(object sender, RoutedEventArgs e)
        {
            if (cbx_Order.Text != null && cbx_Order.Text != "" && tb_Order1.Text != null && tb_Order1.Text != "" && tb_Order2.Text != null && tb_Order2.Text != "" && cbx_Order3.Text != null && cbx_Order3.Text != "" && dg_Order.ItemsSource != null && Convert.ToInt32(tb_Order2.Text) > 0)
            {

                int a = Convert.ToInt32(cbx_Order.SelectedValue.ToString());
                int b = Convert.ToInt32(cbx_Order3.SelectedValue.ToString());
                decimal c = Convert.ToDecimal(tb_Order2.Text.ToString());
                var value = (dg_Order.SelectedValue as DataRowView).Row[0];
                order.UpdateQueryOrder(a, tb_Order1.Text, c, b, (int)value);
                dg_Order.ItemsSource = order.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_Order_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Order.SelectedValue != null)
            {
                cbx_Order.Text = (dg_Order.SelectedValue as DataRowView).Row[1].ToString();
                tb_Order1.Text = (dg_Order.SelectedValue as DataRowView).Row[2].ToString();
                tb_Order2.Text = (dg_Order.SelectedValue as DataRowView).Row[3].ToString();
                cbx_Order3.Text = (dg_Order.SelectedValue as DataRowView).Row[4].ToString();
            }
        }

        private void Button_Click_Create_Supplier_Product(object sender, RoutedEventArgs e)
        {
            if (cbx_Supplier_Product.Text != null && cbx_Supplier_Product.Text != "" && cbx_Supplier_Product1.Text != null && cbx_Supplier_Product1.Text != "" && tb_Supplier_Product2.Text != null && tb_Supplier_Product2.Text != "" && Convert.ToInt32(tb_Supplier_Product2.Text) > 0)
            {
                decimal a = Convert.ToDecimal(tb_Supplier_Product2.Text);
                int b = Convert.ToInt32(cbx_Supplier_Product.SelectedValue.ToString());
                int c = Convert.ToInt32(cbx_Supplier_Product1.SelectedValue.ToString());
                supplier_product.InsertQuerySupplierProduct(b, c, a);
                dg_Supplier_Product.ItemsSource = supplier_product.GetData() ;
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_Supplier_Product(object sender, RoutedEventArgs e)
        {
            if (dg_Supplier_Product.SelectedValue != null)
            {
                var value = (dg_Supplier_Product.SelectedValue as DataRowView).Row[0];
                supplier_product.DeleteQuerySupplierProduct((int)value);
                dg_Supplier_Product.ItemsSource = supplier_product.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_Supplier_Product(object sender, RoutedEventArgs e)
        {
            if (cbx_Supplier_Product.Text != null && cbx_Supplier_Product.Text != "" && cbx_Supplier_Product1.Text != null && cbx_Supplier_Product1.Text != "" && tb_Supplier_Product2.Text != null && tb_Supplier_Product2.Text != "" && dg_Supplier_Product.SelectedValue != null && Convert.ToInt32(tb_Supplier_Product2.Text) > 0)
            {
                decimal a = Convert.ToDecimal(tb_Supplier_Product2.Text);
                int b = Convert.ToInt32(cbx_Supplier_Product.SelectedValue.ToString());
                int c = Convert.ToInt32(cbx_Supplier_Product1.SelectedValue.ToString());
                var value = (dg_Supplier_Product.SelectedValue as DataRowView).Row[0];
                supplier_product.UpdateQuerySupplierProduct(b, c, a, (int)value);
                dg_Supplier_Product.ItemsSource = supplier_product.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_Supplier_Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Supplier_Product.SelectedValue != null)
            {
                cbx_Supplier_Product.Text = (dg_Supplier_Product.SelectedValue as DataRowView).Row[1].ToString();
                cbx_Supplier_Product1.Text = (dg_Supplier_Product.SelectedValue as DataRowView).Row[2].ToString();
                tb_Supplier_Product2.Text = (dg_Supplier_Product.SelectedValue as DataRowView).Row[3].ToString();
            }
        }

        private void Button_Click_Create_payment(object sender, RoutedEventArgs e)
        {
            if (cbx_payment.Text != null && cbx_payment.Text != "" && Convert.ToInt32(cbx_payment.Text) > 0)
            {
                int b = Convert.ToInt32(cbx_payment.SelectedValue);
                payment.InsertQueryPayment(b);
                dg_payment.ItemsSource = payment.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_payment(object sender, RoutedEventArgs e)
        {
            if (dg_payment.SelectedValue != null)
            {
                var value = (dg_payment.SelectedValue as DataRowView).Row[0];
                payment.DeleteQueryPayment((int)value);
                dg_payment.ItemsSource = payment.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_payment(object sender, RoutedEventArgs e)
        {
            if (cbx_payment.Text != null && cbx_payment.Text != "" && dg_payment.SelectedValue != null && Convert.ToInt32(cbx_payment.Text) > 0)
            {
                var value = (dg_payment.SelectedValue as DataRowView).Row[0];
                int b = Convert.ToInt32(cbx_payment.SelectedValue);
                payment.UpdateQueryPayment(b, (int)value);
                dg_payment.ItemsSource = payment.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_payment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_payment.SelectedValue != null)
            {
                cbx_payment.Text = (dg_payment.SelectedValue as DataRowView).Row[1].ToString();
            }
        }

        private void Button_Click_Create_Order_Item(object sender, RoutedEventArgs e)
        {
            if (cbx_Order_Item.Text != null && cbx_Order_Item.Text != "" && tb_Order_Item2.Text != null && tb_Order_Item2.Text != "" && Convert.ToInt32(cbx_Order_Item1.Text) > 0 && Convert.ToInt32(tb_Order_Item2.Text) > 0)
            {
                int с = Convert.ToInt32(cbx_Order_Item1.SelectedValue.ToString());
                int b = Convert.ToInt32(cbx_Order_Item.SelectedValue.ToString());
                int a = Convert.ToInt32(tb_Order_Item2.Text.ToString());
                order_item.InsertQueryOrderItem(b, с, a);
                dg_Order_Item.ItemsSource = order_item.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_Order_Item(object sender, RoutedEventArgs e)
        {
            if (dg_Order_Item.SelectedValue != null)
            {
                var value = (dg_Order_Item.SelectedValue as DataRowView).Row[0];
                order_item.DeleteQueryOrderItem((int)value);
                dg_Order_Item.ItemsSource = order_item.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_Order_Item(object sender, RoutedEventArgs e)
        {
            if (cbx_Order_Item.Text != null && cbx_Order_Item.Text != "" && tb_Order_Item2.Text != null && tb_Order_Item2.Text != "" && Convert.ToInt32(cbx_Order_Item1.Text) >= 0 && Convert.ToInt32(tb_Order_Item2.Text) >= 0)
            {
                int с = Convert.ToInt32(cbx_Order_Item1.SelectedValue.ToString());
                int b = Convert.ToInt32(cbx_Order_Item.SelectedValue.ToString());
                int a = Convert.ToInt32(tb_Order_Item2.Text.ToString());
                var value = (dg_Order_Item.SelectedValue as DataRowView).Row[0];
                order_item.UpdateQueryOrderItem(b, с, a, (int)value);
                dg_Order_Item.ItemsSource = order_item.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_Order_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Order_Item.SelectedValue != null)
            {
                cbx_Order_Item.Text = (dg_Order_Item.SelectedValue as DataRowView).Row[1].ToString();
                cbx_Order_Item1.Text = (dg_Order_Item.SelectedValue as DataRowView).Row[3].ToString();
                tb_Order_Item2.Text = (dg_Order_Item.SelectedValue as DataRowView).Row[2].ToString();
            }
        }
    }
}
