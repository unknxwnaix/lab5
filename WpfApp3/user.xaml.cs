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
    /// Логика взаимодействия для user.xaml
    /// </summary>
    public partial class user : Window
    {
        customersTableAdapter customers = new customersTableAdapter();
        productsTableAdapter products = new productsTableAdapter();
        promotionsTableAdapter promotion = new promotionsTableAdapter();    
        public user()
        {
            InitializeComponent();
            FullUpdate();
        }
        public void FullUpdate()
        {
            dg_Customer.ItemsSource = customers.GetData();
            dg_Product.ItemsSource = products.GetData();
            cbx_Product3.ItemsSource = promotion.GetData();
            cbx_Product3.DisplayMemberPath = "название";
            cbx_Product3.SelectedValuePath = "айди";
            dg_Promotion.ItemsSource = promotion.GetData();
        }
        private void Button_Click_Create_Customer(object sender, RoutedEventArgs e)
        {
            if (tb_Customer.Text != null && tb_Customer.Text != "" && tb_Customer1.Text != null && tb_Customer1.Text != "" && tb_Customer2.Text != null && tb_Customer2.Text != "")
            {
                customers.InsertQueryCustomer(tb_Customer.Text, tb_Customer1.Text, tb_Customer2.Text);
                dg_Customer.ItemsSource = customers.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_Customer(object sender, RoutedEventArgs e)
        {
            if (dg_Customer.SelectedValue != null)
            {
                var value = (dg_Customer.SelectedValue as DataRowView).Row[0];
                customers.DeleteQueryCustomer((int)value);
                dg_Customer.ItemsSource = customers.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_Customer(object sender, RoutedEventArgs e)
        {
            if (tb_Customer.Text != null && tb_Customer.Text != "" && tb_Customer1.Text != null && tb_Customer1.Text != "" && tb_Customer2.Text != null && tb_Customer2.Text != "" && dg_Customer.SelectedValue != null)
            {
                var value = (dg_Customer.SelectedValue as DataRowView).Row[0];
                customers.UpdateQueryCustomer(tb_Customer.Text, tb_Customer1.Text, tb_Customer2.Text, (int)value);
                dg_Customer.ItemsSource = customers.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_Customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Customer.SelectedValue != null)
            {
                tb_Customer.Text = (dg_Customer.SelectedValue as DataRowView).Row[1].ToString();
                tb_Customer1.Text = (dg_Customer.SelectedValue as DataRowView).Row[2].ToString();
                tb_Customer2.Text = (dg_Customer.SelectedValue as DataRowView).Row[3].ToString();
            }
        }
        private void Button_Click_Create_Product(object sender, RoutedEventArgs e)
        {
            if (tb_Product.Text != null && tb_Product.Text != "" && tb_Product1.Text != null && tb_Product2.Text != "" && tb_Product2.Text != null && tb_Product2.Text != "" && cbx_Product3.Text != null && cbx_Product3.Text != "" && Convert.ToInt32(tb_Product2.Text) > 0)
            {
                decimal a = Convert.ToDecimal(cbx_Product3.SelectedValue.ToString());
                int b = (int)cbx_Product3.SelectedValue;
                products.InsertQueryProduct(tb_Product.Text, tb_Product1.Text, a, b);
                dg_Product.ItemsSource = products.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_Product(object sender, RoutedEventArgs e)
        {
            if (dg_Product.SelectedValue != null)
            {
                var value = (dg_Product.SelectedValue as DataRowView).Row[0];
                products.DeleteQueryProduct((int)value);
                dg_Product.ItemsSource = products.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_Product(object sender, RoutedEventArgs e)
        {
            if (tb_Product.Text != null && tb_Product.Text != "" && tb_Product1.Text != null && tb_Product2.Text != "" && tb_Product2.Text != null && tb_Product2.Text != "" && cbx_Product3.Text != null && cbx_Product3.Text != "" && dg_Product.SelectedItem != null && Convert.ToInt32(tb_Product2.Text) > 0)
            {
                decimal a = Convert.ToDecimal(tb_Product2.Text);
                int b = (int)cbx_Product3.SelectedValue;
                var value = (dg_Product.SelectedValue as DataRowView).Row[0];
                products.UpdateQueryProduct(tb_Product.Text, tb_Product1.Text, a, b, (int)value);
                dg_Product.ItemsSource = products.GetData();
                
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Product.SelectedValue != null)
            {
                tb_Product.Text = (dg_Product.SelectedValue as DataRowView).Row[1].ToString();
                tb_Product1.Text = (dg_Product.SelectedValue as DataRowView).Row[2].ToString();
                tb_Product2.Text = (dg_Product.SelectedValue as DataRowView).Row[3].ToString();
                cbx_Product3.Text = (dg_Product.SelectedValue as DataRowView).Row[4].ToString();
            }
        }

        private void Button_Click_Create_Promotion(object sender, RoutedEventArgs e)
        {
            if (tb_Promotion.Text != null && tb_Promotion.Text != "" && tb_Promotion1.Text != null && tb_Promotion1.Text != "" && tb_Promotion2.Text != null && tb_Promotion2.Text != "" && tb_Promotion3.Text != null && tb_Promotion3.Text != "" && Convert.ToInt32(tb_Promotion3.Text) > 0)
            {
                double a = Convert.ToDouble(tb_Promotion4.Text);
                decimal b = Convert.ToDecimal(tb_Promotion4.Text);
                promotion.InsertQueryPromotion(tb_Promotion.Text, tb_Promotion1.Text, tb_Promotion2.Text, tb_Promotion3.Text,  b);
                dg_Promotion.ItemsSource = promotion.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_Promotion(object sender, RoutedEventArgs e)
        {
            if (dg_Promotion.SelectedValue != null)
            {
                var value = (dg_Promotion.SelectedValue as DataRowView).Row[0];
                promotion.DeleteQueryPromotion((int)value);
                dg_Promotion.ItemsSource = promotion.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_Promotion(object sender, RoutedEventArgs e)
        {
            if (tb_Promotion.Text != null && tb_Promotion.Text != "" && tb_Promotion1.Text != null && tb_Promotion1.Text != "" && tb_Promotion2.Text != null && tb_Promotion2.Text != "" && tb_Promotion3.Text != null && tb_Promotion3.Text != "" && dg_Promotion.SelectedItem != null && Convert.ToInt32(tb_Promotion3.Text) > 0)
            {
                var value = (dg_Promotion.SelectedValue as DataRowView).Row[0];
                decimal b = Convert.ToDecimal(tb_Promotion4.Text);
                promotion.UpdateQueryPromotion(tb_Promotion.Text, tb_Promotion1.Text, tb_Promotion2.Text, tb_Promotion3.Text, b, (int)value);
                dg_Promotion.ItemsSource = promotion.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_Promotion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Promotion.SelectedValue != null)
            {
                tb_Promotion.Text = (dg_Promotion.SelectedValue as DataRowView).Row[1].ToString();
                tb_Promotion1.Text = (dg_Promotion.SelectedValue as DataRowView).Row[2].ToString();
                tb_Promotion2.Text = (dg_Promotion.SelectedValue as DataRowView).Row[3].ToString();
                tb_Promotion3.Text = (dg_Promotion.SelectedValue as DataRowView).Row[4].ToString();
                tb_Promotion4.Text = (dg_Promotion.SelectedValue as DataRowView).Row[5].ToString();
            }
        }

        private void Upload_Btn_Click(object sender, RoutedEventArgs e)
        {
            List<Customers> list = Converter.DeserializeObject<List<Customers>>();
            foreach(var item in list)
            {
                customers.InsertQueryCustomer(item.name, item.email, item.phone);
            }
            FullUpdate();
        }
    }
}
